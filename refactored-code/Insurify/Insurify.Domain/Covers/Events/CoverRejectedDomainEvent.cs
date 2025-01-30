using Insurify.Domain.Abstractions;

namespace Insurify.Domain.Covers.Events;

public sealed record CoverRejectedDomainEvent(Guid CoverId) : IDomainEvent;
