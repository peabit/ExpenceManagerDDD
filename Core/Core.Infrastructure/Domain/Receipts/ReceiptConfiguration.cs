using Core.Domain.AggregatesModel.Categories;
using Core.Domain.AggregatesModel.Receipts;
using Core.Domain.Users;
using Core.Infrastructure.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Infrastructure.Domain.Receipts;

public class ReceiptConfiguration : IEntityTypeConfiguration<Receipt>
{
    public void Configure(EntityTypeBuilder<Receipt> builder)
    {
        builder.ToTable("Receipts");
        builder.HasKey(x => x.Id);

        builder
            .Property(r => r.Id)
            .HasConversion(id => new ReceiptId(id));

        builder
            .Property(r => r.User)
            .HasColumnName("UserId")
            .HasConversion(userId => new User(userId));

        builder.Ignore(r => r.Total);

        builder.OwnsMany(r => r.Items, itemsBuilder =>
        {
            itemsBuilder.ToTable("ReceiptItems");

            itemsBuilder
                .Property(i => i.Id)
                .HasConversion(id => new ReceiptItemId(id));

            itemsBuilder
                .Property(i => i.CategoryId)
                .HasConversion(id => new CategoryId(id));

            itemsBuilder.Ignore(i => i.Coast);
        });

        FillTestData(builder);
    }

    private void FillTestData(EntityTypeBuilder<Receipt> builder)
    {
        var user = new User("2cc51776-02de-4bf0-81e1-ecd0f2845879");
        
        var items = new List<ReceiptItem>();
        
        items.Add(new ReceiptItem(new CategoryId("bbe60c26-d65a-4761-91cd-c6f93fb30798"), "Булочка с маком", price: 35, quantity: 2));
        items.Add(new ReceiptItem(new CategoryId("bbe60c26-d65a-4761-91cd-c6f93fb30798"), "Булочка с творогом", price: 50, quantity: 1));
        items.Add(new ReceiptItem(new CategoryId("7b6ed301-51a7-473a-94b1-9882a5c960de"), "Банан", price: 50));

        var receipt = new Receipt(user, "Пятёрочка", DateTime.Parse("2023-06-21 13:46:42.137"), items);

        builder.HasData(receipt);   
    }
}