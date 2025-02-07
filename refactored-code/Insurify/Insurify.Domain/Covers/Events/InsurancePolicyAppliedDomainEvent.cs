using Insurify.Domain.Abstractions;

namespace Insurify.Domain.Covers.Events;

/// <summary>
/// Event that is raised when an insurance policy is applied for.
/// </summary>
/// <param name="InsurancePolicyId">The id of the policy</param>
public sealed record InsurancePolicyAppliedDomainEvent(Guid InsurancePolicyId) : IDomainEvent;
