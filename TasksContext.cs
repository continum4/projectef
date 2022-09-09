using Microsoft.EntityFrameworkCore;
using t = projectef.Models;

namespace projectef;

public class TasksContext: DbContext
{
  public DbSet<t.Category> Categories {get; set;} = default!;
  public DbSet<t.Task> Tasks {get; set;} = default!;

  public TasksContext(DbContextOptions<TasksContext> options): base(options) {}
}