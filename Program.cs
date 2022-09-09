using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectef;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<TasksContext>(option => option.UseInMemoryDatabase("TasksDb"));
builder.Services.AddDbContext<TasksContext>(option => option.UseMySQL(builder.Configuration.GetConnectionString("cnTasks")));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", ([FromServices] TasksContext dbContext) =>
{
  dbContext.Database.EnsureCreated();
  return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());
});

app.Run();
