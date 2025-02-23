using Insurify.Application.Extensions;
using Insurify.Domain.Customers;
using Insurify.Domain.InsurancePolicies;
using Insurify.Domain.Insurances;
using Insurify.Domain.Shared;

namespace Insurify.Infrastructure.Services.ElligibilityServices;

/// <summary>
/// Checker for home insurance eligibility.
/// <para>
/// A customer is elligible for home insurance if they are 18 years of older.
/// </para>
/// </summary>
internal class HomeInsuranceEligibilityChecker : IEligibilityCheckerFactory
{
    private const int ElligibilityAge = 18;

    public bool IsEligible(
        Insurance insurance,
        Customer customer,
        DateTime startDate,
        Money insuredAmount,
        CancellationToken cancellationToken = default)
    {
        var age = customer.BirthDate.CalculateAge();

        return age >= ElligibilityAge;
    }
}