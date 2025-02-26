using Insurify.Domain.InsurancePolicies;

namespace Insurify.Infrastructure.Repositories
{
    internal sealed class InsurancePolicyRepository : Repository<InsurancePolicy>, IInsurancePolicyRepository
    {
        public InsurancePolicyRepository(ApplicationDbContext dbContext) : base(dbContext) 
        {
        }

        public Task<ICollection<InsurancePolicy>> GetPoliciesByInsuranceId(int insuranceId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
