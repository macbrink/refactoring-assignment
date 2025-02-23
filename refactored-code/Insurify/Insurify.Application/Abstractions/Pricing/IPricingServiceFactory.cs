using Insurify.Domain.InsurancePolicies;
using Insurify.Domain.Insurances;

namespace Insurify.Application.Abstractions.Pricing;

/// <summary>
/// Factory for creating pricing services per Isurance
/// </summary>
public interface IPricingServiceFactory
{
    /// <summary>
    /// Get the pricing service for the insurance
    /// </summary>
    /// <param name="insurance">Insurance instance</param>
    /// <returns>PricingService for this Insurance instance</returns>
    IPricingService GetPricingService(Insurance insurance);
}
