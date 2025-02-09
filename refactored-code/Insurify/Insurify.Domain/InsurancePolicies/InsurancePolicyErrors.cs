using Insurify.Domain.Abstractions;

namespace Insurify.Domain.InsurancePolicies;

public class InsurancePolicyErrors
{
    public static readonly Error NotFound = new(
        "InsurancePolicy.NotFound",
        "The insurance policy with the specified identifier was not found");

    public static readonly Error Age = new(
        "InsurancePolicy.Age",
        "The current customer's age is not allowed for this insurance policy");

    public static readonly Error NotAppliedFor = new(
        "InsurancePolicy.NotAppliedFor",
        "The insurance policy is not pending");

    public static readonly Error NotConfirmed = new(
        "InsurancePolicy.NotReserved",
        "The insurance policy is not confirmed");

    public static readonly Error AlreadyStarted = new(
        "InsurancePolicy.AlreadyStarted",
        "The insurance policy has already started");
}

