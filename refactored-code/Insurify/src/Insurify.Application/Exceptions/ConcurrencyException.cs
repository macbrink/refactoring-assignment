namespace Insurify.Application.Exceptions;

/// <summary>
/// Represents a concurrency exception.
/// </summary>
public sealed class ConcurrencyException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ConcurrencyException"/> class.
    /// </summary>
    /// <param name="message">a Message</param>
    /// <param name="innerException">The exception caught</param>
    public ConcurrencyException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}