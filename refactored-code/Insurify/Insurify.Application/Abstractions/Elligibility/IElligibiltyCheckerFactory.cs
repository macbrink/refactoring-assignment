using Insurify.Domain.InsurancePolicies;
using Insurify.Domain.Insurances;

namespace Insurify.Application.Abstractions.Elligibility;

/// <summary>
/// Factory for creating Elligibilty Checkers
/// </summary>
public interface IElligibiltyCheckerFactory
{
    /// <summary>
    /// Get the eligibility checker for the insurance
    /// </summary>
    /// <param name="insurance">An Insurance Instance</param>
    /// <returns>ElligibilityCheker for this Insurance</returns>
    IEligibilityCheckerFactory GetEligibilityChecker(Insurance insurance);
}
