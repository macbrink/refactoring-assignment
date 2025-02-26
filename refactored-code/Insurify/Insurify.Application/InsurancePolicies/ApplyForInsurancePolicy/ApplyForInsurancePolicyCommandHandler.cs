using Insurify.Application.Abstractions.Elligibility;
using Insurify.Application.Abstractions.Pricing;
using Insurify.Application.Exceptions;
using Insurify.Domain.Abstractions;
using Insurify.Domain.Customers;
using Insurify.Domain.InsurancePolicies;
using Insurify.Domain.Insurances;

namespace Insurify.Application.InsurancePolicies.ApplyForInsurancePolicy;

/// <summary>
/// Handler for the <see cref="ApplyForInsurancePolicyCommand" />
/// </summary>
public class ApplyForInsurancePolicyCommandHandler
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IInsuranceRepository _insuranceRepository;
    private readonly IInsurancePolicyRepository _insurancePolicyRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IElligibiltyCheckerFactory _eligibilityCheckerFactory;
    private readonly IPricingServiceFactory _pricingServicesFactory;
    private readonly IIdCreator _idCreator;

    /// <summary>
    /// Constructor for the handler
    /// </summary>
    /// <param name="customerRepository">ICustomerRepository instance</param>
    /// <param name="insuranceRepository">IInsuranceRepository instance</param>
    /// <param name="insurancePolicyRepository">IInsurancePolicyRepository instance</param>
    /// <param name="unitOfWork">IUnitOfWork instance</param>
    /// <param name="eligibilityCheckerFactory">IEligibilityChecker instance</param>
    /// <param name="pricingServiceFactory">IPricingServiceFactory instance</param>
    /// <param name="idCreator">IIdCreator instance</param>
    public ApplyForInsurancePolicyCommandHandler(
        ICustomerRepository customerRepository,
        IInsuranceRepository insuranceRepository,
        IInsurancePolicyRepository insurancePolicyRepository,
        IUnitOfWork unitOfWork,
        IElligibiltyCheckerFactory eligibilityCheckerFactory,
        IPricingServiceFactory pricingServiceFactory,
        IIdCreator idCreator)
    {
        _customerRepository = customerRepository;
        _insuranceRepository = insuranceRepository;
        _eligibilityCheckerFactory = eligibilityCheckerFactory;
        _insurancePolicyRepository = insurancePolicyRepository;
        _unitOfWork = unitOfWork;
        _pricingServicesFactory = pricingServiceFactory;
        _idCreator = idCreator;
    }

    /// <summary>
    /// Handles the ApplyForInsurancePolicyCommand
    /// </summary>
    /// <param name="command"><see cref="ApplyForInsurancePolicyCommand"/></param>
    /// <param name="result"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Result<int>> HandleAsync(
        ApplyForInsurancePolicyCommand command,
        Result result,
        CancellationToken cancellationToken = default)
    {
        var customer = await _customerRepository.GetByIdAsync(command.SubscriberId, cancellationToken);
        var insurance = await _insuranceRepository.GetByIdAsync(command.InsuranceId, cancellationToken);

        if(insurance is null)
        {
            return Result.Failure<int>(InsurancesErrors.NotFound);
        }

        if(customer is null)
        {
            return default!;
        }

        var pricingService = _pricingServicesFactory.GetPricingService(insurance);

        var insurancePolicy = InsurancePolicy.ApplyFor(
            _idCreator,
            insurance,
            customer,
            command.StartDate,
            command.InsuredAmount,
            pricingService);

        try
        {

            _insurancePolicyRepository.Add(insurancePolicy);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return insurancePolicy.Id;
        }
        catch(ConcurrencyException)
        {
            return Result.Failure<int>(InsurancePoliciesErrors.NotSaved);
        }
    }
}

