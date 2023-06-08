using System.Data;

namespace Core.Infrastructure.Application;

public interface ISqlConnectionFactory
{
    IDbConnection Create();
}