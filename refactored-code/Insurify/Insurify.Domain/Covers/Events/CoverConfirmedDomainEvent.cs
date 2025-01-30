using Insurify.Domain.Abstractions;

namespace Insurify.Domain.Covers.Events;

public sealed record CoverConfirmedDomainEvent(Guid CoverId) : IDomainEvent;
