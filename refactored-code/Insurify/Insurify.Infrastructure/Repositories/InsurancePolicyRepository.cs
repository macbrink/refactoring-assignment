using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insurify.Domain.InsurancePolicies;

namespace Insurify.Infrastructure.Repositories
{
    class InsurancePolicyRepository : Repository<InsurancePolicy>, IInsurancePolicyRepository
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
