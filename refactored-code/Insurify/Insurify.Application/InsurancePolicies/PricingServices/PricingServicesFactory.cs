using Insurify.Domain.InsurancePolicies;
using Insurify.Domain.Insurances;

namespace Insurify.Application.InsurancePolicies.PricingServices;

/// <summary>
/// Factory for creating pricing services per Isurance
/// </summary>
internal class PricingServicesFactory
{
    /// <summary>
    /// Get the pricing service for the insurance
    /// </summary>
    /// <param name="insurance">an Insurance Instamce</param>
    /// <returns>an object that implements <see cref="IPricingService"/></returns>
    public static IPricingService GetPricingService(Insurance insurance)
    {
        return new HomeInsurancePricingService();
    }
}