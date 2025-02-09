using Insurify.Domain.Abstractions;

namespace Insurify.Domain.InsurancePolicies;

/// <summary>
/// Errors related to insurance policies.
/// </summary>
public class InsurancePolicyErrors
{
    /// <summary>
    /// Represents an error when the insurance policy is not found.
    /// </summary>
    public static readonly Error NotFound = new(
        "InsurancePolicy.NotFound",
        "The insurance policy with the specified identifier was not found");

    /// <summary>
    /// Represents an error when the current customer's age is not allowed for this insurance policy.
    /// </summary>
    public static readonly Error Age = new(
        "InsurancePolicy.Age",
        "The current customer's age is not allowed for this insurance policy");

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
}

