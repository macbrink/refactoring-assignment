namespace Insurify.Application.Exceptions;

/// <summary>
/// Represents a validation error.
/// </summary>
/// <param name="PropertyName">The validated property</param>
/// <param name="ErrorMessage">The error message</param>
public sealed record ValidationError(string PropertyName, string ErrorMessage);