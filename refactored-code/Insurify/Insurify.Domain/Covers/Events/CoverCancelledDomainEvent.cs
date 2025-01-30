using Insurify.Domain.Abstractions;

namespace Insurify.Domain.Covers.Events;

public sealed record CoverCancelledDomainEvent(Guid CoverId) : IDomainEvent;
