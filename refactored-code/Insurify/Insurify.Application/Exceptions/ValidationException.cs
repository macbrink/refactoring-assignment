namespace Insurify.Application.Exceptions;

/// <summary>
/// Represents a validation exception.
/// </summary>
public sealed class ValidationException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationException"/> class.
    /// </summary>
    /// <param name="errors">All <see cref="ValidationError"/> for this validation</param>
    public ValidationException(IEnumerable<ValidationError> errors)
    {
        Errors = errors;
    }

    /// <summary>
    /// Gets all <see cref="ValidationError"/> for this validation.
    /// </summary>
    public IEnumerable<ValidationError> Errors { get; }
}