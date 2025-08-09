using System.Data.Common;

namespace Tasky.Modules.Tasks.Application.Abstractions.Data;

public interface IDbConnectionFactory
{
    ValueTask<DbConnection> OpenConnectionAsync();
}