using Core.Domain.Common;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Infrastructure.Domain.Common;

public static class EntityTypeBuilderExtensions
{
    public static PropertyBuilder<TEntity> HasConversion<TEntity, TId>(this PropertyBuilder<TEntity> propertyBuilder, Func<string, TId> idFactory)
        where TId : EntityIdBase
    {
        var converter = new ValueConverter<TId, string>(
            convertFromProviderExpression: id => idFactory(id),
            convertToProviderExpression: id => id.ToString()
        );

        return propertyBuilder.HasConversion(converter);
    }
}