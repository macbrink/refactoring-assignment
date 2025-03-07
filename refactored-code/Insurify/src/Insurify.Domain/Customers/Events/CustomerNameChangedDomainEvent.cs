using Insurify.Domain.Abstractions;

namespace Insurify.Domain.Customers.Events;

/// <summary>
/// Domain event representing a customer's name being changed
/// </summary>
/// <param name="CustomerId">The Customer's Id</param>
public sealed record CustomerNammeChangedDomainEvent(int CustomerId) : IDomainEvent;
