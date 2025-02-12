using Insurify.Domain.Customers;
using Insurify.Domain.Insurances;
using Insurify.Domain.Shared;

namespace Insurify.Domain.InsurancePolicies;

/// <summary>
/// Interface for a Service for checking insurance policy eligibility.
/// </summary>
public interface IInsuranceEligibilityChecker
{
    /// <summary>
    /// Checks if a customer is eligible for an insurance policy.
    /// </summary>
    /// <param name="insurance">Insurance instance</param>
    /// <param name="customer">Customer instance</param>
    /// <param name="startDate">Start date for the policy</param>
    /// <param name="insuredAmount">Insured amount</param>
    /// <param name="cancellationToken">a CancellationToken</param>
    /// <returns></returns>
    bool IsEligible(
        Insurance insurance, 
        Customer customer, 
        DateTime startDate, 
        Money insuredAmount,
        CancellationToken cancellationToken = default);
}
