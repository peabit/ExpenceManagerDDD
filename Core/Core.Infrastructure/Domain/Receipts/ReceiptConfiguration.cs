using Core.Domain.AggregatesModel.Receipts;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Infrastructure.Domain.Receipts;

public class ReceiptConfiguration : IEntityTypeConfiguration<Receipt>
{
    public void Configure(EntityTypeBuilder<Receipt> builder)
    {
        builder.ToTable("Receipts");
        builder.HasKey(x => x.Id);

        builder.Ignore(s => s.UserId);

        builder
            .Property(r => r.Id)
            .HasConversion(
                convertToProviderExpression: id => id.ToString(),
                convertFromProviderExpression: id => new ReceiptId(new Guid(id))
            );

        builder.OwnsMany(r => r.Items, cnfg =>
        {
            cnfg.HasKey(i => i.Id);

            cnfg.Property(i => i.Id).HasConversion(
                convertToProviderExpression: id => id.ToString(),
                convertFromProviderExpression: id => new ReceiptItemId(new Guid(id))
            );
        });
    }
}