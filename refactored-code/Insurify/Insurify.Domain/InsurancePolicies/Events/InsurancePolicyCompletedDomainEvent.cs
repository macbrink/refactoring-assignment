using Insurify.Domain.Abstractions;

namespace Insurify.Domain.InsurancePolicies.Events;

/// <summary>
/// Domain event representing an insurance policy being completed
/// </summary>
/// <param name="InsurancePolicyId">The insurance policy Id</param>
public sealed record InsurancePolicyCompletedDomainEvent(int InsurancePolicyId) : IDomainEvent;
