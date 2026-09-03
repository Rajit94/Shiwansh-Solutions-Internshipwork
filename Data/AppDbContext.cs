using Microsoft.EntityFrameworkCore;
using ShiwanshApi.Models;

namespace ShiwanshApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Language> Languages { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<District> Districts { get; set; }
    }
}