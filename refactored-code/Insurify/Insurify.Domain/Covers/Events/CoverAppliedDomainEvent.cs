using Insurify.Domain.Abstractions;

namespace Insurify.Domain.Covers.Events;

public sealed record CoverAppliedDomainEvent(Guid CoverId) : IDomainEvent;
