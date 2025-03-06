using Insurify.Domain.InsurancePolicies;

namespace Insurify.Application.InsurancePolicies.GetById;

/// <summary>
/// Handler for the <see cref="GetInsurancePolicyQuery"/>.
/// </summary>
public sealed class GetInsurancePolicyQueryHandler
{
    private readonly IInsurancePolicyRepository _insurancePolicyRepository;

    /// <summary>
    /// Constructor for the <see cref="GetInsurancePolicyQueryHandler"/>.
    /// </summary>
    /// <param name="insurancePolicyRepository"><see cref="IInsurancePolicyRepository" /></param>
    public GetInsurancePolicyQueryHandler(IInsurancePolicyRepository insurancePolicyRepository)
    {
        _insurancePolicyRepository = insurancePolicyRepository;
    }

    /// <summary>
    /// Handles the <see cref="GetInsurancePolicyQuery"/>.
    /// </summary>
    /// <param name="query">the query</param>
    /// <param name="cancellationToken">a cancellation token</param>
    /// <returns></returns>
    /// <exception cref="Exception">Exception thrown when insurance policy is not found y Id</exception>
    public async Task<InsurancePolicyResponse> Handle(GetInsurancePolicyQuery query, CancellationToken cancellationToken)
    {
        var insurancePolicy = await _insurancePolicyRepository.GetByIdAsync(query.InsurancePolicyId, cancellationToken);
        return insurancePolicy is null
            ? throw new Exception($"Insurance policy with id {query.InsurancePolicyId} was not found.")
            : new InsurancePolicyResponse
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
            };
    }
}

