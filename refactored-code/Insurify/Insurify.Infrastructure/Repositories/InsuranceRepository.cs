using Insurify.Application.Abstractions.Data;
using Insurify.Domain.Insurances;

namespace Insurify.Infrastructure.Repositories;

/// <summary>
/// Repository for the Insurance entity.
/// </summary>
internal sealed class InsuranceRepository : Repository<Insurance>, IInsuranceRepository
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InsuranceRepository"/> class.
    /// </summary>
    /// <param name="dbContext">The ApplicationDbContext</param>
    public InsuranceRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    /// <summary>
    /// Gets an insurance entity by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the insurance entity.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The insurance entity.</returns>
    public new async Task<Insurance?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await base.GetByIdAsync(id, cancellationToken);
    }

    /// <summary>
    /// Adds a new insurance entity.
    /// </summary>
    /// <param name="insurance">The insurance entity to add.</param>
    public new void Add(Insurance insurance)
    {
        base.Add(insurance);
    }
}

