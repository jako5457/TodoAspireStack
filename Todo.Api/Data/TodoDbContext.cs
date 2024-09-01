using Microsoft.EntityFrameworkCore;
using Todo.Api.Data.Entities;

namespace Todo.Api.Data
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options) { }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
