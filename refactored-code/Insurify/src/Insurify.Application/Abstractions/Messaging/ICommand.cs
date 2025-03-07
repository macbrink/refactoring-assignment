using Insurify.Domain.Abstractions;
using MediatR;

namespace Insurify.Application.Abstractions.Messaging;

/// <summary>
/// Interface for the command
/// </summary>
public interface ICommand : IRequest<Result>, IBaseCommand
{
}

/// <summary>
/// Interface for the command foir a Response
/// </summary>
/// <typeparam name="TReponse">Reposne type</typeparam>
public interface ICommand<TReponse> : IRequest<Result<TReponse>>, IBaseCommand
{
}

/// <summary>
/// Interface for the base command
/// </summary>
public interface IBaseCommand
{
}