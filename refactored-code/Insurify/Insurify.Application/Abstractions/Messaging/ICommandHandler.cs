using Insurify.Domain.Abstractions;
using MediatR;

namespace Insurify.Application.Abstractions.Messaging;

/// <summary>
/// Interface for the command
/// </summary>
/// <typeparam name="TCommand"><see cref="ICommand"/></typeparam>
public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, Result>
    where TCommand : ICommand
{
}

/// <summary>
/// Interface for the command with a response
/// </summary>
/// <typeparam name="TCommand">ICommand Type</typeparam>
/// <typeparam name="TResponse">IResponse Type</typeparam>
public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>>
    where TCommand : ICommand<TResponse>
{
}