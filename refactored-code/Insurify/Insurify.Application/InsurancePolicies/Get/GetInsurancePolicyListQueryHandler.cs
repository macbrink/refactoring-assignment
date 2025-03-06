using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insurify.Application.Abstractions.Data;
using Insurify.Application.Abstractions.Messaging;

namespace Insurify.Application.InsurancePolicies.Get;

class GetInsurancePolicyListQueryHandler : IQueryHandler<GetInsurancePolicyListQuery, List<InsurancesPolicyListResponse>>
{
    private readonly IApplicationDbContext _context;

    public GetInsurancePolicyListQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }


}
