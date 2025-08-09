using MediatR;
using OmdhSoft.Tasky.Modules.Shared.Domain.Abstractions;

namespace OmdhSoft.Tasky.Modules.Shared.Domain.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
