using Core.Domain.AggregatesModel.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Infrastructure.Domain.Common;
using Core.Domain.Users;

namespace Core.Infrastructure.Domain.Categories;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder
            .HasKey(c => c.Id);

        builder
            .ToTable("Categories");

        //builder
        //    .HasOne<Category>()
        //    .WithMany()
        //    .HasForeignKey(c => c.ParentCategoryId)
        //    .OnDelete(DeleteBehavior.Cascade);

        builder
            .Property(c => c.Id)
            .HasConversion(id => new CategoryId(id));

        builder
            .Property(c => c.ParentCategoryId)
            .HasConversion(id => new CategoryId(id));

        builder
            .Property(c => c.User)
            .HasColumnName("UserId")
            .HasConversion(id => new User(id));
    }
}