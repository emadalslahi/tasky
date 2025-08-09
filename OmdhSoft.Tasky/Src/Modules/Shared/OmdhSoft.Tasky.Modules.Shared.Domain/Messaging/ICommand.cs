using OmdhSoft.Tasky.Modules.Shared.Domain.Abstractions;

namespace OmdhSoft.Tasky.Modules.Shared.Domain.Messaging;

using MediatR;

public interface ICommand : IRequest<Result>, IBaseCommand;

public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand;

public interface IBaseCommand;
