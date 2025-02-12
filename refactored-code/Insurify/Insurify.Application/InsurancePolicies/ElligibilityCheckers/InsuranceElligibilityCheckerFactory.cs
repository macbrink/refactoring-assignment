using Insurify.Domain.InsurancePolicies;
using Insurify.Domain.Insurances;

namespace Insurify.Application.InsurancePolicies.ElligibilityCheckers;

/// <summary>
/// Factory for creating <see cref="InsuranceElligibilityChecker"/> instances.
/// </summary>
internal class InsuranceElligibilityCheckerFactory
{
    /// <summary>
    /// Get the eligibility checker for the insurance
    /// </summary>
    /// <param name="insurance"><see cref="Insurance"/></param>
    /// <returns>an object that implements <see cref="IInsuranceEligibilityChecker"/></returns>
    public static IInsuranceEligibilityChecker GetElligibilityChecker(Insurance insurance)
    {
        return new HomeInsuranceEligibilityChecker();
    }
}