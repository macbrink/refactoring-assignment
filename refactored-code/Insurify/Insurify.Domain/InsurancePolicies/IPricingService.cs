using Insurify.Domain.Insurances;
using Insurify.Domain.Shared;

namespace Insurify.Domain.InsurancePolicies;

public interface IPricingService
{
    Money CalculatePremium(
        Guid insuranceId,
        Guid customerId,
        DateTime startDate,
        Money insuredAmount,
        CancellationToken cancellationToken = default);
}
