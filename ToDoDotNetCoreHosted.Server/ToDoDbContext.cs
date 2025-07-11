using Microsoft.EntityFrameworkCore;
using ToDoDotNetCoreHosted.Shared;

public class ToDoDbContext : DbContext
{
    public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options) { }

    public DbSet<ToDoItem> ToDoItems { get; set; }
}