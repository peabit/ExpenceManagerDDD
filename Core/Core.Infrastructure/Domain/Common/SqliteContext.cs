using Core.Domain.AggregatesModel.Receipts;
using Core.Infrastructure.Domain.Receipts;
using Microsoft.EntityFrameworkCore;


namespace Core.Infrastructure.Domain.Common
{
    public class SqliteContext : DbContext
    {
        public SqliteContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Receipt> Receipts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data source = test.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ReceiptConfiguration());
        }
    }
}