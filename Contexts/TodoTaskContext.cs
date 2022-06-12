using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Contexts;

public class TodoTaskContext : DbContext
{
    public TodoTaskContext(DbContextOptions<TodoTaskContext> options)
        : base(options)
    {
        
    }

    public DbSet<TodoTask> TodoTasks { get; set; }
    public DbSet<User> Users { get; set; }
}
