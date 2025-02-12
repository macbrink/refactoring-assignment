using Insurify.Domain.InsurancePolicies;
using Insurify.Domain.Insurances;
using Insurify.Domain.Insurances.Events;
using MediatR;

namespace Insurify.Application.Insurances.ChangeInsurancePrice;

internal sealed class InsurencePriceChhangedEventHandler : INotificationHandler<InsurancePriceChangedDomainEvent>
{
    private readonly IInsuranceRepository _insuranceRepository;
    private readonly IInsurancePolicyRepository _insurancePolicyRepository;
    private readonly IPricingService _pricingService;

    public InsurencePriceChhangedEventHandler(
        IInsuranceRepository insuranceRepository,
        IInsurancePolicyRepository insurancePolicyRepository,
        IPricingService pricingService
        )
    {
        _insuranceRepository = insuranceRepository;
        _insurancePolicyRepository = insurancePolicyRepository;
        _pricingService = pricingService;
    }

    public async Task Handle(InsurancePriceChangedDomainEvent notification, CancellationToken cancellationToken)
    {
        var insurance = await _insuranceRepository.GetByIdAsync(notification.InsurancePolicyId);

        if(insurance == null)
        {
            return;
        }

        var insurancePolicies = await _insurancePolicyRepository.GetPoliciesByInsuranceId(insurance.Id);

        insurancePolicies.ToList().ForEach(policy =>
        {
            policy.UpdateFee(_pricingService);

            // add error hanlding
        });
    }
}

