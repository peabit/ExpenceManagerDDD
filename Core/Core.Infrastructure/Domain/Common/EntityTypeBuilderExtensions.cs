using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Infrastructure.Domain.Common;

public static class EntityTypeBuilderExtensions
{
    public static PropertyBuilder<TEntity> HasConversion<TEntity, T>(this PropertyBuilder<TEntity> propertyBuilder, Func<string, T> convertFromProvider)
    {
        var converter = new ValueConverter<T, string>(
            convertFromProviderExpression: id => convertFromProvider(id),
            convertToProviderExpression: id => id.ToString()
        );

        return propertyBuilder.HasConversion(converter);
    }
}