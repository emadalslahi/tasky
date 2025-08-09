using MediatR;
using OmdhSoft.Tasky.Modules.Shared.Domain.Abstractions;

namespace OmdhSoft.Tasky.Modules.Shared.Domain.Messaging;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>;
