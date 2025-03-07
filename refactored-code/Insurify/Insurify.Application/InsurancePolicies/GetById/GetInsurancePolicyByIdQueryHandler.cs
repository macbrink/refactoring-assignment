using Insurify.Application.Abstractions.Data;
using Insurify.Application.Abstractions.Messaging;
using Insurify.Domain.Abstractions;
using Insurify.Domain.InsurancePolicies;
using Microsoft.EntityFrameworkCore;

namespace Insurify.Application.InsurancePolicies.GetById;

/// <summary>
/// Handler for the <see cref="GetInsurancePolicyByIdQuery"/>.
/// </summary>
public sealed class GetInsurancePolicyByIdQueryHandler : IQueryHandler<GetInsurancePolicyByIdQuery, InsurancePolicyResponse>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// Constructor for the <see cref="GetInsurancePolicyByIdQueryHandler"/>.
    /// </summary>
    /// <param name="insurancePolicyRepository"><see cref="IInsurancePolicyRepository" /></param>
    public GetInsurancePolicyByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Handles the <see cref="GetInsurancePolicyByIdQuery"/>.
    /// </summary>
    /// <param name="query">the query</param>
    /// <param name="cancellationToken">a cancellation token</param>
    /// <returns></returns>
    /// <exception cref="Exception">Exception thrown when insurance policy is not found y Id</exception>
    public async Task<Result<InsurancePolicyResponse>> Handle(GetInsurancePolicyByIdQuery query, CancellationToken cancellationToken)
    {
        var insurancePolicy = await _context.InsurancePolicies.
            Select(insurancePolicy => new InsurancePolicyResponse
            {
                Id = insurancePolicy.Id,
                InsuranceId = insurancePolicy.InsuranceId,
                SubscriberId = insurancePolicy.SubscriberId,
                StartDate = insurancePolicy.StartDate,
                InsuredAmount = insurancePolicy.InsuredAmount.Amount,
                InsuredCurrency = insurancePolicy.InsuredAmount.Currency.Code,
                FeeAmount = insurancePolicy.Fee.Amount,
                FeeCurrency = insurancePolicy.Fee.Currency.Code,
                Status = insurancePolicy.Status
            })
            .FirstOrDefaultAsync(insurancePolicy => insurancePolicy.Id == query.InsurancePolicyId, cancellationToken);

        if (insurancePolicy is null)
        {
            return Result.Failure<InsurancePolicyResponse>(InsurancePoliciesErrors.NotFound);
        }

        return insurancePolicy;
    }
}

