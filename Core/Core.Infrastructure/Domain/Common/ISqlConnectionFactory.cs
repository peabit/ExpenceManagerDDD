using System.Data;

namespace Core.Infrastructure.Domain.Common;

public interface ISqlConnectionFactory
{
    IDbConnection Create();
}