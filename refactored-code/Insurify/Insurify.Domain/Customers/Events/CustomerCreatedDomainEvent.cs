using Insurify.Domain.Abstractions;

namespace Insurify.Domain.Customers.Events;

public sealed record CustomerCreatedDomainEvent(Guid CustomerId) : IDomainEvent;
