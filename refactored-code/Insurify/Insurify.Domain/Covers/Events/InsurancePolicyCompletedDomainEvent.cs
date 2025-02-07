using Insurify.Domain.Abstractions;

namespace Insurify.Domain.Covers.Events;

public sealed record InsurancePolicyCompletedDomainEvent(Guid CoverId) : IDomainEvent;
