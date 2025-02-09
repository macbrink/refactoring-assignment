using Insurify.Domain.Abstractions;

namespace Insurify.Domain.InsurancePolicies.Events;

public sealed record InsurancePolicyRejectedDomainEvent(Guid CoverId) : IDomainEvent;
