using Insurify.Domain.Abstractions;

namespace Insurify.Domain.Covers.Events;

public sealed record InsurancePolicyAppliedDomainEvent(Guid CoverId) : IDomainEvent;
