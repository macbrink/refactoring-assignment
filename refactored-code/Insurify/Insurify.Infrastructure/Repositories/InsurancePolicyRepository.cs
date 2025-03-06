using Insurify.Domain.InsurancePolicies;

namespace Insurify.Infrastructure.Repositories
{
    internal sealed class InsurancePolicyRepository : Repository<InsurancePolicy>, IInsurancePolicyRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public InsurancePolicyRepository(ApplicationDbContext dbContext) : base(dbContext) 
        {
            _dbContext = dbContext;
        }

        public Task<ICollection<InsurancePolicy>> GetPoliciesByInsuranceId(int insuranceId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
