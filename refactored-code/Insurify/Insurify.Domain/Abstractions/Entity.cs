namespace Insurify.Domain.Abstractions;

/// <summary>
/// Base class for all entities.
/// </summary>
public abstract class Entity
{
    private readonly List<IDomainEvent> _domainEvents = [];

    /// <summary>
    /// Initializes a new instance of the <see cref="Entity"/> class.
    /// </summary>
    /// <param name="idCreator">The external Id Creator for all entities</param>
    protected Entity(IIdCreator idCreator)
    {
        Id = idCreator.CreateId();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Entity"/> class.
    /// </summary>
    protected Entity()
    {
    }

    /// <summary>
    /// Gets the id for this Entity.
    /// </summary>
    public int Id { get; init; }


    /// <summary>
    /// Wether the entity is active or not.
    /// <para>
    /// Use this property to mark an entity for soft delete.
    /// </para>
    public bool IsActive { get; private set; } = true;

    /// <summary>
    /// Gets the domain events.
    /// </summary>
    /// <returns>List of current domain events</returns>
    public IReadOnlyList<IDomainEvent> GetDomainEvents()
    {
        return _domainEvents.ToList();
    }

    /// <summary>
    /// Clears the domain events.
    /// </summary>
    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    /// <summary>
    /// Raises a domain event.
    /// </summary>
    /// <param name="domainEvent">a domain avent</param>
    protected void RaiseDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}
