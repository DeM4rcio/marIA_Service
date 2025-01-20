using app.Migrations;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
 
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}