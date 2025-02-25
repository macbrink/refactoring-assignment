using Insurify.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Insurify.Infrastructure.Repositories;

/// <summary>
/// Base class for repositories.
/// </summary>
/// <typeparam name="T">Type stored in the repository</typeparam>
internal abstract class Repository<T>
    where T : Entity
{
    /// <summary>
    /// The Entity Franework <see cref="DbContext"/>.
    /// </summary>
    protected readonly ApplicationDbContext DbContext;

    /// <summary>
    /// Initializes a new instance of the <see cref="Repository{T}"/> class.
    /// </summary>
    /// <param name="dbContext">The ApplicationDbContext</param>
    protected Repository(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public async Task<List<T>> GetValuesAsync(
        CancellationToken cancellationToken = default)
    {
        return await DbContext
            .Set<T>()
            .Where(item => item.IsActive)
            .ToListAsync(cancellationToken);
    }

    /// <summary>
    /// Gets an entity by its id.
    /// </summary>
    public async Task<T?> GetByIdAsync(
        int id,
        CancellationToken cancellationToken = default)
    {
        return await DbContext
            .Set<T>()
            .FirstOrDefaultAsync(item => item.Id == id && item.IsActive, cancellationToken);
    }

    /// <summary>
    /// Adds an entity to the repository.
    /// </summary>
    /// <param name="entity">an Entity instance</param>
    public virtual void Add(T entity)
    {
        DbContext.Add(entity);
    }
    /// <summary>
    /// Updates an entity in the repository.
    /// </summary>
    /// <param name="entity">>an Entity instance</param>
    public virtual void Update(T entity)
    {
        DbContext.Update(entity);
    }

    /// <summary>
    /// Soft-Removes an entity from the repository.
    /// <para>
    /// Deactivates the Entity
    /// </para>
    /// </summary>
    /// <param name="entity">an Entity instance</param>
    public virtual void Remove(T entity)
    {
        if (entity is Entity)
        {
            var entityT = entity as Entity;
            entityT.DeActivate();
        }
        DbContext.Update(entity);
    }

    /// <summary>
    /// Removes the Entity from the DbContext
    /// </summary>
    /// <param name="entity"></param>
    public virtual void RemoveFromDbContext(T entity)
    {
        DbContext.Remove(entity);
    }
}