using Insurify.Domain.Customers;
using Insurify.Domain.InsurancePolicies;
using Insurify.Domain.Insurances;
using Insurify.Domain.Shared;

namespace Insurify.Application.InsurancePolicies.PricingServices;

/// <summary>
/// A Pricing Service for Home Insurance.
/// <para>
/// <see cref="IPricingService"/> 
/// </para>
/// </summary>
internal class HomeInsurancePricingService : IPricingService
{
    /// <summary>
    /// Calculates the premium for a Home Insurance policy.
    public Money CalculatePremium(
        Insurance insurance,
        Customer customer,
        DateTime startDate,
        Money insuredAmount)
    {
        var basePrice = insurance.Price;

        var upchargeMapping = new Dictionary<string, decimal>
        {
            { "10", 30 },
            { "11", 30 },
            { "35", 30 },
            { "56", 10 },
            { "30", 50 },
            { "65", 15 },
            { "97", 70 },
            { "7", 5 }
        };

        var upcharge = upchargeMapping
            .Where(entry => customer.Address.PostalCode.StartsWith(entry.Key))
            .Select(entry => new Money(entry.Value, basePrice.Currency))
            .FirstOrDefault() ?? Money.Zero(basePrice.Currency);

        var discount = customer.HasSecurityCertificate ? new Money(-15, basePrice.Currency) : Money.Zero(basePrice.Currency);

        return basePrice + upcharge + discount;
    }
}