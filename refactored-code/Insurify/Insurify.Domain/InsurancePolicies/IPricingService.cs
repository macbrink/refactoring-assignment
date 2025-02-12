using Insurify.Domain.Customers;
using Insurify.Domain.Insurances;
using Insurify.Domain.Shared;

namespace Insurify.Domain.InsurancePolicies;

/// <summary>
/// Interface for a Service for calculating insurance policy premiums.
/// </summary>
public interface IPricingService
{
    /// <summary>
    /// Calculates the premium for an insurance policy.
    /// </summary>
    /// <param name="insurance">Insurance Id</param>
    /// <param name="customer">Customer Id.</param>
    /// <param name="startDate">The policy start date</param>
    /// <param name="insuredAmount">The insured amount</param>
    /// <returns></returns>
    Money CalculatePremium(
        Insurance insurance,
        Customer customer,
        DateTime startDate,
        Money insuredAmount);
}