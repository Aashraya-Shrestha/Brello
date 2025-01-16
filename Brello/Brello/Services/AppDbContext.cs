using Microsoft.EntityFrameworkCore;
using Brello.Models;
using Brello.Services;


namespace Brello.Services
{
    public class AppDbContext : DbContext
    {
        public required DbSet<User>? Users { get; set; }
        public required DbSet<Transaction>? Transactions { get; set; } // Add Transactions DbSet
        public required DbSet<Debt>? Debts { get; set; }



        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            EnsureDatabase();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=brello.db");
            }
        }


        private void EnsureDatabase()
        {
            
           // Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Transaction entity
            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.ToTable("Transactions");
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Description).IsRequired();
                entity.Property(t => t.Amount).IsRequired();
                entity.Property(t => t.TransactionType).IsRequired();
            });

            // Configure DebtModel entity
            modelBuilder.Entity<Debt>(entity =>
            {
                entity.ToTable("Debts");
                entity.HasKey(d => d.Id);
                entity.Property(d => d.Amount).IsRequired();
                entity.Property(d => d.Source).IsRequired();
                entity.Property(d => d.DebtDueDate).IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }



    }
}
