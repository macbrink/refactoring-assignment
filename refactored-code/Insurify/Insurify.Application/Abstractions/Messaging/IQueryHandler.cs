using Insurify.Domain.Abstractions;
using MediatR;

namespace Insurify.Application.Abstractions.Messaging;

/// <summary>
/// Interface for the query
/// </summary>
/// <typeparam name="TQuery">IQuery Type</typeparam>
/// <typeparam name="TResponse">IResponse Type</typeparam>
public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}