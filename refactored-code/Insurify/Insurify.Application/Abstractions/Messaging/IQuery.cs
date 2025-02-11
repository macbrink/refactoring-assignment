using Insurify.Domain.Abstractions;
using MediatR;

namespace Insurify.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}