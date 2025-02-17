using Insurify.Domain.Abstractions;

namespace Insurify.Domain.InsurancePolicies.Events;

/// <summary>
/// Domain event representing an insurance policy being confirmed
/// </summary>
/// <param name="InsurancePolicyId">The insurance policy event></param>
public sealed record InsurancePolicyrConfirmedDomainEvent(int InsurancePolicyId) : IDomainEvent;
