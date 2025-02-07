namespace Insurify.Domain.Abstractions;

/// <summary>
/// Represents a unit of work for storing data
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// Save all changes in the dataset
    /// </summary>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>integer (e.g. rows affected)</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
