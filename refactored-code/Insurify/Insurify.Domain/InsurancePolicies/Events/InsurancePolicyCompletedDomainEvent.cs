using Insurify.Domain.Abstractions;

namespace Insurify.Domain.InsurancePolicies.Events;

public sealed record InsurancePolicyCompletedDomainEvent(Guid CoverId) : IDomainEvent;
