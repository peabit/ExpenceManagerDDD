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
        builder.HasKey(c => c.Id);

        builder
            .Property(c => c.Id)
            .HasConversion(id => new CategoryId(id));

        builder
            .Property(c => c.ParentId)
            .HasConversion(id => new CategoryId(id));

        builder
            .Property(c => c.User)
            .HasConversion(id => new User(id)); 
    }
}
