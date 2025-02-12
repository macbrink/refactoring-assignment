using Insurify.Domain.Abstractions;

namespace Insurify.Domain.InsurancePolicies;

/// <summary>
/// Errors related to insurance policies.
/// </summary>
public class InsurancePoliciesErrors
{
    /// <summary>
    /// Represents an error when the insurance policy is not found.
    /// </summary>
    public static readonly Error NotFound = new(
        "InsurancePolicy.NotFound",
        "The insurance policy with the specified identifier was not found");

    /// <summary>
    /// Represents an error when the insurance policy is not pending.
    /// </summary>
    public static readonly Error NotAppliedFor = new(
        "InsurancePolicy.NotAppliedFor",
        "The insurance policy is not pending");

    /// <summary>
    /// Represents an error when the insurance policy is not reserved.
    /// </summary>
    public static readonly Error NotConfirmed = new(
        "InsurancePolicy.NotReserved",
        "The insurance policy is not confirmed");

    /// <summary>
    /// Represents an error when the insurance policy has already started.
    /// </summary>
    public static readonly Error AlreadyStarted = new(
        "InsurancePolicy.AlreadyStarted",
        "The insurance policy has already started");

    /// <summary>
    /// Represents an error when the customer is not elligible for the requested insurance policy.
    /// </summary>
    public static readonly Error NotEligible = new(
        "InsurancePolicy.NotElligible",
        "The customer is not elligible for the requested insurance policy");

    public static readonly Error NotSaved = new(
        "InsurancePolicy.NotSaves",
        "The insurance policy is not saved to the data storage");
}

