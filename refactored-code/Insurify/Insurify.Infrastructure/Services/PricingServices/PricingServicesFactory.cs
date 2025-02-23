using Insurify.Application.Abstractions.Pricing;
using Insurify.Domain.InsurancePolicies;
using Insurify.Domain.Insurances;

namespace Insurify.Infrastructure.Services.PricingServices;

/// <summary>
/// Factory for creating pricing services per Isurance
/// </summary>
internal class PricingServicesFactory : IPricingServiceFactory
{
    /// <summary>
    /// Get the pricing service for the insurance
    /// </summary>
    /// <param name="insurance">an Insurance Instamce</param>
    /// <returns>an object that implements <see cref="IPricingService"/></returns>
    public IPricingService GetPricingService(Insurance insurance)
    {
        return new HomeInsurancePricingService();
    }
}