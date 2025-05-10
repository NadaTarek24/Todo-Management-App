using Microsoft.EntityFrameworkCore;
using TodoApp.Models;

namespace TodoApp.Data
{
    // It is used by Entity Framework Core to interact with the database.
    public class AppDbContext : DbContext
    {
        // This allows configuration of the context (e.g., specifying the database provider and connection string).
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Each Todo entity will be mapped to a row in this table.
        public DbSet<Todo> Todos { get; set; }
    }
}
