using Microsoft.EntityFrameworkCore;
using Brello.Models;

namespace Brello.Services
{
    public class AppDbContext : DbContext
    {
        public required DbSet<User>? Users { get; set; }
        public required DbSet<Transaction>? Transactions { get; set; } // Add Transactions DbSet


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            EnsureDatabase();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=brello.db");
        }

        private void EnsureDatabase()
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Transaction Entity
            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Description).IsRequired();
                entity.Property(t => t.Amount).IsRequired();
                entity.Property(t => t.TransactionType).IsRequired();
            });

         
            base.OnModelCreating(modelBuilder);
        }

    }
}
