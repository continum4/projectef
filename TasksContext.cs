using Microsoft.EntityFrameworkCore;
using t = projectef.Models;

namespace projectef;

public class TasksContext: DbContext
{
  public DbSet<t.Category> Categories {get; set;} = default!;
  public DbSet<t.Task> Tasks {get; set;} = default!;

  public TasksContext(DbContextOptions<TasksContext> options): base(options) {}

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<t.Category>(category =>
    {
      category.ToTable("Category");
      category.HasKey(c => c.CategoryId);
      category.Property(c => c.Name).IsRequired().HasMaxLength(150);
      category.Property(c => c.Description);
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
    });
  }
}