using Core.Domain.AggregatesModel.Categories;
using Core.Domain.AggregatesModel.Receipts;
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

        builder.OwnsOne(r => r.User, userBuilder =>
        {
            userBuilder.Property("_id").HasColumnName("UserId");
        });

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
    }
}