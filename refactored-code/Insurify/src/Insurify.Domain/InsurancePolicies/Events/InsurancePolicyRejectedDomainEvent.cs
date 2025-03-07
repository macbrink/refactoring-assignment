using Insurify.Domain.Abstractions;

namespace Insurify.Domain.InsurancePolicies.Events;

/// <summary>
/// Domain event representing an insurance policy being rejected
/// </summary>
/// <param name="InsurancePolicyId">RThe insurance policy Id</param>
public sealed record InsurancePolicyRejectedDomainEvent(int InsurancePolicyId) : IDomainEvent;
