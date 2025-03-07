namespace Insurify.Domain.Abstractions;

/// <summary>
/// Represents an error.
/// </summary>
/// <param name="Code">The error code</param>
/// <param name="Name">The error name</param>
public record Error(string Code, string Name)
{
    /// <summary>
    /// Represents an error with no code or name.
    /// </summary>
    public static readonly Error None = new(string.Empty, string.Empty);

    /// <summary>
    /// Represents an error when a null value is provided.
    /// </summary>
    public static readonly Error NullValue = new("Error.NullValue", "Null value was provided");
}
