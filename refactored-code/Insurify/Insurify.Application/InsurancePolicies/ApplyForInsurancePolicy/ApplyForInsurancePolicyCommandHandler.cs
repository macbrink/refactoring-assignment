using Insurify.Application.Exceptions;
using Insurify.Application.InsurancePolicies.ElligibilityCheckers;
using Insurify.Application.InsurancePolicies.PricingServices;
using Insurify.Domain.Abstractions;
using Insurify.Domain.Customers;
using Insurify.Domain.InsurancePolicies;
using Insurify.Domain.Insurances;

namespace Insurify.Application.InsurancePolicies.ApplyForInsurancePolicy;

/// <summary>
/// Handler for the <see cref="cref="ApplyForInsurancePolicyCommand" />
/// </summary>
public class ApplyForInsurancePolicyCommandHandler
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IInsuranceRepository _insuranceRepository;
    private readonly IInsurancePolicyRepository _insurancePolicyRepository;
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// Constructor for the handler
    /// </summary>
    /// <param name="customerRepository">ICustomerRepository instance</param>
    /// <param name="insuranceRepository">IInsuranceRepository instance</param>
    /// <param name="insurancePolicyRepository">IInsurancePolicyRepository instance</param>
    /// <param name="unitOfWork">IUnitOfWork instance</param>
    public ApplyForInsurancePolicyCommandHandler(
        ICustomerRepository customerRepository,
        IInsuranceRepository insuranceRepository,
        IInsurancePolicyRepository insurancePolicyRepository,
        IUnitOfWork unitOfWork)
    {
        _customerRepository = customerRepository;
        _insuranceRepository = insuranceRepository;
        _insurancePolicyRepository = insurancePolicyRepository;
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Handles the ApplyForInsurancePolicyCommand
    /// </summary>
    /// <param name="command"><see cref="ApplyForInsurancePolicyCommand"/></param>
    /// <param name="result"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Result<Guid>> HandleAsync(
        ApplyForInsurancePolicyCommand command,
        Result result,
        CancellationToken cancellationToken = default)
    {
        var customer = await _customerRepository.GetByIdAsync(command.SubscriberId, cancellationToken);
        var insurance = await _insuranceRepository.GetByIdAsync(command.InsuranceId, cancellationToken);

        if(insurance is null)
        {
            return Result.Failure<Guid>(InsurancesErrors.NotFound);
        }

        if(customer is null)
        {
            return default!;
        }

        var insuranceElligibilityChecker = InsuranceElligibilityCheckerFactory.GetElligibilityChecker(insurance);

        if(!insuranceElligibilityChecker.IsEligible(
            insurance,
            customer,
            command.StartDate,
            command.InsuredAmount)
        {
            return Result.Failure<Guid>(InsurancePoliciesErrors.NotEligible);
        }

        var pricingService = PricingServicesFactory.GetPricingService(insurance);

        try
        {
            var insurancePolicy = InsurancePolicy.ApplyFor(
                insurance,
                customer,
                command.StartDate,
                command.InsuredAmount,
                pricingService);

            _insurancePolicyRepository.Add(insurancePolicy);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return insurancePolicy.Id;
        }
        catch(ConcurrencyException)
        {
            return Result.Failure<Guid>(InsurancePoliciesErrors.NotSaved);
        }


    }
}

