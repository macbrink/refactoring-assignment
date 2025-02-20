using Insurify.Application.Abstractions.Data;
using Insurify.Domain.Insurances;

namespace Insurify.Infrastructure.Repositories;

/// <summary>
/// Repository for the Insurance entity.
/// </summary>
internal sealed class InsuranceRepository : Repository<Insurance>, IInsuranceRepository
{
    public InsuranceRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}

