using Core.Application.Common;
using Dapper;
using System.Data;

namespace Core.Infrastructure.Domain.Common;

public sealed class SqlQueryExecutor : ISqlQueryExecutor, IDisposable
{
    private readonly ISqlConnectionFactory _connectionFactory;
    private IDbConnection? _connection;

    private IDbConnection Connection
    {
        get
        {
            if (_connection is null || _connection.State is not ConnectionState.Open)
            {
                _connection = _connectionFactory.Create();
                _connection.Open();
            }

            return _connection;
        }
    }

    public SqlQueryExecutor(ISqlConnectionFactory connectionFactory)
        => _connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));

    public async Task<IEnumerable<TResult>> Query<TResult>(string query, object parameters)
        => await Connection.QueryAsync<TResult>(query, parameters);

    public async Task<TResult> QueryFirstOrDefault<TResult>(string query, object parameters)
        => await Connection.QueryFirstOrDefaultAsync<TResult>(query, parameters);

    public void Dispose()
        => _connection?.Dispose();
}