using Insurify.Domain.Abstractions;

namespace Insurify.Domain.Covers;

public class CoverErrors
{
    public static readonly Error NotFound = new(
        "Cover.NotFound",
        "The cover with the specified identifier was not found");

    public static readonly Error Age = new(
        "Cover.Age",
        "The current customer's age is not allowed for this cover");

    public static readonly Error NotAppliedFor = new(
        "Cover.NotAppliedFor",
        "The cover is not pending");

    public static readonly Error NotConfirmed = new(
        "Cover.NotReserved",
        "The cover is not confirmed");

    public static readonly Error AlreadyStarted = new(
        "Cover.AlreadyStarted",
        "The cover has already started");
}

