using Insurify.Domain.Insurances;
using Insurify.Domain.Shared;

namespace Insurify.Domain.InsurancePolicies;

/// <summary>
/// Service for calculating insurance policy premiums.
/// </summary>
public interface IPricingService
{
    /// <summary>
    /// Calculates the premium for an insurance policy.
    /// </summary>
    /// <param name="insuranceId">Insurance Id</param>
    /// <param name="customerId">Customer Id.</param>
    /// <param name="startDate">The policy start date</param>
    /// <param name="insuredAmount">The insured amount</param>
    /// <param name="cancellationToken">a cancellation token</param>
    /// <returns></returns>
    Money CalculatePremium(
        Guid insuranceId,
        Guid customerId,
        DateTime startDate,
        Money insuredAmount,
        CancellationToken cancellationToken = default);
}
