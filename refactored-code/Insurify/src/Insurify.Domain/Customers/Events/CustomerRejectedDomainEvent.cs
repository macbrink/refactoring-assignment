using Insurify.Domain.Abstractions;

namespace Insurify.Domain.Customers.Events;

/// <summary>
/// Domain event representing a customer has been rejected
/// </summary>
/// <param name="CustomerId">The Customer's Id</param>
public sealed record CustomerRejectedDomainEvent(int CustomerId) : IDomainEvent;
