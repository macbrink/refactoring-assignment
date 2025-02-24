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
}

