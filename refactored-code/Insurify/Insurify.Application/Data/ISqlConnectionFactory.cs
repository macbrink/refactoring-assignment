using System.Data;

namespace Insurify.Application.Data;

public interface ISqlConnectionFactory
{
    IDbConnection CreateConnection();
}