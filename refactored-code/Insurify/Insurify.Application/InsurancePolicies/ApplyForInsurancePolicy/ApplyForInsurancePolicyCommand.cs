using Insurify.Application.Abstractions.Messaging;
using Insurify.Domain.Shared;

namespace Insurify.Application.InsurancePolicies.ApplyForInsurancePolicy;

/// <summary>
/// Recorde to apply for an insurance policy.
/// </summary>
/// <param name="InsuranceId">The id of the insurance the policy is for</param>
/// <param name="SubscriberId">The subcriber for this policy</param>
/// <param name="StartDate">Start date for this policy</param>
/// <param name="InsuredAmount">The insured amount on this policy</param>
public record ApplyForInsurancePolicyCommand(
    Guid InsuranceId,
    Guid SubscriberId,
    DateTime StartDate,
    Money InsuredAmount) : ICommand<Guid>;
 