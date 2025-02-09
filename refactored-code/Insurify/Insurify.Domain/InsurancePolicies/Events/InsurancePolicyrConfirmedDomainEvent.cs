using Insurify.Domain.Abstractions;

namespace Insurify.Domain.InsurancePolicies.Events;

public sealed record InsurancePolicyrConfirmedDomainEvent(Guid CoverId) : IDomainEvent;
