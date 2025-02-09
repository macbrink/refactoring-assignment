using Insurify.Domain.Abstractions;

namespace Insurify.Domain.InsurancePolicies.Events;

public sealed record InsurancePolicyCancelledDomainEvent(Guid CoverId) : IDomainEvent;
