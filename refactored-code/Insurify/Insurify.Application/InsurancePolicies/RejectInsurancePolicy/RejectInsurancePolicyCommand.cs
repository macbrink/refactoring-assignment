using Insurify.Application.Abstractions.Messaging;

namespace Insurify.Application.InsurancePolicies.RejectInsurancePolicy;

/// <summary>
/// Command to reject an insurance policy.
/// </summary>
/// <param name="InsurancePolicyId">The Id for the Insurancepolicy to reject</param>
public sealed record RejectInsurancePolicyCommand(Guid InsurancePolicyId) : ICommand;
