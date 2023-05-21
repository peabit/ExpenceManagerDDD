using Microsoft.Data.Sqlite;
using System.Data;

namespace Core.Infrastructure.Domain.Common
{
    public sealed class SqliteConnectionFactory : ISqlConnectionFactory
    {
        private readonly string _connectionString;

        public SqliteConnectionFactory(string connectionString) 
            => _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));

        public IDbConnection Create()
            => new SqliteConnection(_connectionString);
    }
}