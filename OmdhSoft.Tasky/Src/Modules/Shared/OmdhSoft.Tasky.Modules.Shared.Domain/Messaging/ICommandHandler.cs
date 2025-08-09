using MediatR;
using OmdhSoft.Tasky.Modules.Shared.Domain.Abstractions;

namespace OmdhSoft.Tasky.Modules.Shared.Domain.Messaging;


public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand, Result>
    where TCommand : ICommand;

public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>>
    where TCommand : ICommand<TResponse>;
