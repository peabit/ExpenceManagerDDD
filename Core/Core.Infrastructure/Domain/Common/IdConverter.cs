using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Core.Domain.Common;

namespace Core.Infrastructure.Domain.Common;

public class IdConverter<T> : ValueConverter<T, string>
    where T : EntityIdBase
{
    public IdConverter(Func<Guid, T> convertFromProviderExpression)
        : base(
           convertToProviderExpression: id => id.ToString(),
           convertFromProviderExpression: guid => convertFromProviderExpression(new Guid(guid))
        )
    { }
}