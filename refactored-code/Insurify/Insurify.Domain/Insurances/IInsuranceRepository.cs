namespace Insurify.Domain.Insurances;

/// <summary>
/// Represents a repository for insurances.
/// </summary>
public interface IInsuranceRepository
{
    /// <summary>
    /// Gets an insurance by its id.
    /// </summary>
    /// <param name="id">The insurance id</param>
    /// <param name="cancellationToken">a CancellationToken</param>
    /// <returns>Insurance instance</returns>
    Task<Insurance> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Adds an insurance to the repository.
    /// </summary>
    /// <param name="insurance"></param>
    void Add(Insurance insurance);
}
