#nullable enable

using System.Data.Common;
using Dapper;
using MediatR;
using OmdhSoft.Tasky.Modules.Shared.Domain.Abstractions;
using OmdhSoft.Tasky.Modules.Shared.Domain.Messaging;
using Tasky.Modules.Tasks.Application.Abstractions.Data;

namespace Tasky.Modules.Tasks.Application.Tasks.GetTask
{
    internal sealed class GetTaskQueryHandler(IDbConnectionFactory dbConnectionFacktory) : 
        IQueryHandler<GetTaskQuery, TaskResponse?>
    {
        public async Task<Result<TaskResponse?>> Handle(GetTaskQuery request, CancellationToken cancellationToken)
        {
             await using DbConnection connection =await dbConnectionFacktory.OpenConnectionAsync();
             const string sql = $"""
                                SELECT 
                                    id as {nameof(TaskResponse.Id)},
                                    Title as {nameof(TaskResponse.Title)},
                                    Description as {nameof(TaskResponse.Description)},
                                    Priority as {nameof(TaskResponse.Priority)},
                                    DueDate as {nameof(TaskResponse.DueDate)},
                                    AssignedToUserId as {nameof(TaskResponse.AssignedToUserId)}
                                
                                 FROM Tasks WHERE Id = @Id
                                """;
             TaskResponse? response = await connection.QuerySingleOrDefaultAsync(sql,request );
             return response;
        }
    }
   
}
