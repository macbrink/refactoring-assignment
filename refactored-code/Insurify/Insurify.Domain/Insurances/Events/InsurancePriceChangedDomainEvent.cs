using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insurify.Domain.Abstractions;

namespace Insurify.Domain.Insurances.Events;

/// <summary>
/// Event that is raised when the price of an insurance is changed.
/// </summary>
/// <param name="InsurancePolicyId">The id of the Insurance</param>
public sealed record InsurancePriceChangedDomainEvent(Guid InsurancePolicyId) : IDomainEvent;