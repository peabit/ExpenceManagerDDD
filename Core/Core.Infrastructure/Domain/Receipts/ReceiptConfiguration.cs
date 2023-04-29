using Core.Domain.AggregatesModel.Receipts;
using Core.Domain.AggregatesModel.UserAggregate;
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
            .Property(r => r.UserId)
            .UseIdFactory(guid => new UserId(guid));

        builder
            .Property(r => r.Id)
            .UseIdFactory(guid => new ReceiptId(guid));

        builder.Ignore(r => r.Total);

        builder.OwnsMany(r => r.Items, itemsBuilder =>
        {
            itemsBuilder.ToTable("ReceiptItems");
            itemsBuilder.HasKey(i => i.Id);

            itemsBuilder
                .Property(i => i.Id)
                .UseIdFactory(guid => new ReceiptItemId(guid));

            itemsBuilder.Ignore(i => i.Coast);
        });
    }
}