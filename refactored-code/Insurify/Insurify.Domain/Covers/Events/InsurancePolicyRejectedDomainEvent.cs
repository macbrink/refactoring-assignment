using Insurify.Domain.Abstractions;

namespace Insurify.Domain.Covers.Events;

public sealed record InsurancePolicyRejectedDomainEvent(Guid CoverId) : IDomainEvent;
