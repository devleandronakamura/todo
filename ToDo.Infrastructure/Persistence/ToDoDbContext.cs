using Microsoft.EntityFrameworkCore;
using ToDo.Core.Models;

namespace ToDo.Infrastructure.Persistence
{
    public class ToDoDbContext : DbContext
    {
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options) { }

        public DbSet<ToDoModel> ToDo { get; set; }
    }
}