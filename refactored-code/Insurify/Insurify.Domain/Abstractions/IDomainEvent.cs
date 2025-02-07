using MediatR;

namespace Insurify.Domain.Abstractions;

/// <summary>
/// Represents a domain event.
/// </summary>
public interface IDomainEvent : INotification
{
}
