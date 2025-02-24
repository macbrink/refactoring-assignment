using Insurify.Application.Abstractions.Elligibility;
using Insurify.Domain.InsurancePolicies;
using Insurify.Domain.Insurances;

namespace Insurify.Infrastructure.Services.ElligibilityServices;

/// <summary>
/// Factory for creating <see cref="InsuranceElligibilityChecker"/> instances.
/// </summary>
internal class InsuranceElligibilityCheckerFactory : IElligibiltyCheckerFactory
{
    /// <summary>
    /// Get the eligibility checker for the insurance
    /// </summary>
    /// <param name="insurance"><see cref="Insurance"/></param>
    /// <returns>an object that implements <see cref="IEligibilityCheckerFactory"/></returns>
    public IInsuranceEligibilityChecker GetEligibilityChecker(Insurance insurance)
    {
        return new HomeInsuranceEligibilityChecker();
    }
}