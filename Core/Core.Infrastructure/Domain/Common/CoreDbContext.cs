using Core.Domain.AggregatesModel.Categories;
using Core.Domain.AggregatesModel.Receipts;
using Core.Infrastructure.Domain.Categories;
using Core.Infrastructure.Domain.Receipts;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.Domain.Common;

public class CoreDbContext : DbContext
{
    public CoreDbContext()
    {
        Database.EnsureCreated();
    }

    public DbSet<Receipt> Receipts { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data source = test.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ReceiptConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
    }
}