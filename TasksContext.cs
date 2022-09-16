using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MySql.EntityFrameworkCore.Extensions;
using t = projectef.Models;

namespace projectef;

public class TasksContext: DbContext
{
  public DbSet<t.Category> Categories {get; set;} = default!;
  public DbSet<t.Task> Tasks {get; set;} = default!;

  public TasksContext(DbContextOptions<TasksContext> options): base(options) {}

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    List<t.Category> categoriesInit = new List<t.Category>();
    categoriesInit.Add(new t.Category() {
      CategoryId = Guid.Parse("824e8ee9-f83d-42dc-9320-8d1d0cb660be"),
      Name = "Actividades pendientes",
      Weight = 20
    });

    categoriesInit.Add(new t.Category() {
      CategoryId = Guid.Parse("824e8ee9-f83d-42dc-9320-8d1d0cb66002"),
      Name = "Actividades personales",
      Weight = 50
    });

    modelBuilder.Entity<t.Category>(category =>
    {
      category.ToTable("Category");
      category.HasKey(c => c.CategoryId);
      category.Property(c => c.Name).IsRequired().HasMaxLength(150);
      category.Property(c => c.Description);
      category.Property(c => c.Weight);
      category.HasData(categoriesInit);
    });

    List<t.Task> tasksInit = new List<t.Task>();
    tasksInit.Add(new t.Task() {
      TaskId = Guid.Parse("824e8ee9-f83d-42dc-9320-8d1d0cb66023"),
      CategoryId = Guid.Parse("824e8ee9-f83d-42dc-9320-8d1d0cb660be"),
      Title = "Pago de servicios",
      Priority = t.Priority.Media,
      CreatedAt = DateTime.Now
    });

    tasksInit.Add(new t.Task() {
      TaskId = Guid.Parse("824e8ee9-f83d-42dc-9320-8d1d0cb66024"),
      CategoryId = Guid.Parse("824e8ee9-f83d-42dc-9320-8d1d0cb66002"),
      Title = "Terminar tareas",
      Priority = t.Priority.Baja,
      CreatedAt = DateTime.Now
    });

    modelBuilder.Entity<t.Task>(task => {
      task.ToTable("Task");
      task.HasKey(t => t.TaskId);
      task.HasOne(t => t.Category).WithMany(t => t.Tasks).HasForeignKey(t => t.CategoryId);
      task.Property(t => t.Title).IsRequired().HasMaxLength(200);
      task.Property(t => t.Description);
      task.Property(t => t.Priority);
      task.Property(t => t.CreatedAt);
      task.Ignore(t => t.Summary);
      task.HasData(tasksInit);
    });
  }
}

public class MysqlEntityFrameworkDesignTimeServices : IDesignTimeServices
{
    public void ConfigureDesignTimeServices(IServiceCollection serviceCollection)
    {
      serviceCollection.AddEntityFrameworkMySQL();
      new EntityFrameworkRelationalDesignServicesBuilder(serviceCollection).TryAddCoreServices();
    }
}