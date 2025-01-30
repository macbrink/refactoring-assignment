using Insurify.Domain.Insurances;
using Insurify.Domain.Shared;

namespace Insurify.Domain.Covers;

public interface IPricingService
{
    Money CalculatePremium(
        Insurance insurance,
        Guid customerId,
        DateTime startDate,
        CancellationToken cancellationToken = default);
}
