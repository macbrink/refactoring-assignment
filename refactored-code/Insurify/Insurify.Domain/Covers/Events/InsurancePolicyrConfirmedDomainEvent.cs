using Insurify.Domain.Abstractions;

namespace Insurify.Domain.Covers.Events;

public sealed record InsurancePolicyrConfirmedDomainEvent(Guid CoverId) : IDomainEvent;
