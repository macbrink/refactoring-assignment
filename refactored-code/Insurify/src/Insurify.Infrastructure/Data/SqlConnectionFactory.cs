using System.Data;
using Insurify.Application.Abstractions.Data;
using Microsoft.Data.SqlClient;

namespace Insurify.Infrastructure.Data;

/// <summary>
/// Factory for creating SQL connections.
/// </summary>
internal class SqlConnectionFactory : ISqlConnectionFactory
{
    private readonly string _connectionString;

    /// <summary>
    /// Constructor for SqlConnectionFactory.
    /// </summary>
    /// <param name="connectionString">The connection string to use.</param>
    public SqlConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
    }
    /// <summary>
    /// Create a new SQL connection.
    /// </summary>
    /// <returns>A new SQL connection.</returns>
    public IDbConnection CreateConnection()
    {
        var conection = new SqlConnection(_connectionString);
        conection.Open();

        return conection;
    }
}

