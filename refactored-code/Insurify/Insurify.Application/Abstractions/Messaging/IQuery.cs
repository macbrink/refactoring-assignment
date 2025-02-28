using Insurify.Domain.Abstractions;
using MediatR;

namespace Insurify.Application.Abstractions.Messaging;

/// <summary>
/// Interface for the query
/// </summary>
/// <typeparam name="TResponse">IResponse Type</typeparam>
public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}