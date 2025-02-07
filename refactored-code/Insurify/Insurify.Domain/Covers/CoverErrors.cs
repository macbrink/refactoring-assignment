using Insurify.Domain.Abstractions;

namespace Insurify.Domain.Covers;

public class CoverErrors
{
    public static readonly Error NotFound = new(
        "InsurancePolicy.NotFound",
        "The cover with the specified identifier was not found");

    public static readonly Error Age = new(
        "InsurancePolicy.Age",
        "The current customer's age is not allowed for this cover");

    public static readonly Error NotAppliedFor = new(
        "InsurancePolicy.NotAppliedFor",
        "The cover is not pending");

    public static readonly Error NotConfirmed = new(
        "InsurancePolicy.NotReserved",
        "The cover is not confirmed");

    public static readonly Error AlreadyStarted = new(
        "InsurancePolicy.AlreadyStarted",
        "The cover has already started");
}

