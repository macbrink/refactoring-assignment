using Insurify.Domain.Abstractions;

namespace Insurify.Domain.InsurancePolicies.Events;

/// <summary>
/// Domain event representing an insurance policy being cancelled
/// </summary>
/// <param name="InsurancePolicyId">The InsurancePolicy Id</param>
public sealed record InsurancePolicyCancelledDomainEvent(int InsurancePolicyId) : IDomainEvent;
