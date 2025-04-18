﻿using Insurify.Domain.Abstractions;

namespace Insurify.Domain.Customers.Events;

/// <summary>
/// Domain event representing a customer being created
/// </summary>
/// <param name="CustomerId">The Customer's Id</param>
public sealed record CustomerCreatedDomainEvent(int CustomerId) : IDomainEvent;
