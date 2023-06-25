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

        FillTestData(builder);
    }

    private void FillTestData(EntityTypeBuilder<Category> builder)
    {
        var user = new User("2cc51776-02de-4bf0-81e1-ecd0f2845879");

        builder.HasData(
            new Category(user, "Хлебобулочные изделия", id: new CategoryId("bbe60c26-d65a-4761-91cd-c6f93fb30798")),
            new Category(user, "Овощи и фрукты", id: new CategoryId("7b6ed301-51a7-473a-94b1-9882a5c960de"))
        );
    }
}