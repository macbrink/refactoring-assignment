using System.Data;

namespace Insurify.Application.Abstractions.Data;

/// <summary>
/// Interface for the sql connection factory
/// </summary>
public interface ISqlConnectionFactory
{
    /// <summary>
    /// Creates a new connection
    /// </summary>
    /// <returns>A Database conection</returns>
    IDbConnection CreateConnection();
}