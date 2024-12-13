using Microsoft.EntityFrameworkCore;
using OnlineBookstore.Models;

namespace OnlineBookstore.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Constructor to use the connection string from appsettings.json
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet properties for each model
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }

        // Optional: Custom configurations can be added in OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Optionally, you can configure the database schema, relationships, etc.
            modelBuilder.Entity<Book>().ToTable("Books");
            modelBuilder.Entity<User>().ToTable("Users");
        }
    }
}
