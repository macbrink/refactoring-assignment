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

    /// <summary>
    /// Gets an entity by its id.
    /// </summary>
    public async Task<T?> GetByIdAsync(
        int id,
        CancellationToken cancellationToken = default)
    {
        return await DbContext
            .Set<T>()
            .FirstOrDefaultAsync(item => item.Id == id, cancellationToken);
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
    /// Removes an entity from the repository.
    /// </summary>
    /// <param name="entity">an Entity instance</param>
    public virtual void Remove(T entity)
    {
        DbContext.Remove(entity);
    }
}
