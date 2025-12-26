using Expense_Tracker.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace Expense_Tracker.Repository.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Expense> Expenses { get; set; } = null!;
        public DbSet<Budget> Budgets { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Expense>()
                .Property(e => e.Date)
                .HasColumnType("datetime");

            modelBuilder.Entity<Expense>()
                .Property(e => e.CreatedAt)
                .HasColumnType("datetime");

            modelBuilder.Entity<Budget>()
                .Property(b => b.LimitAmount)
                .HasColumnType("decimal(18,2)");

            base.OnModelCreating(modelBuilder);
        }
    }
}
