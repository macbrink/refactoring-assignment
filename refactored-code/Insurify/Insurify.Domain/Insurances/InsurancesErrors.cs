using Insurify.Domain.Abstractions;

namespace Insurify.Domain.Insurances;

/// <summary>
/// Represents errors that can occur with insurances.
/// </summary>
public static class InsurancesErrors
{
    /// <summary>
    /// Represents an error when the insurance is not found.
    /// </summary>
    public static readonly Error NotFound = new(
        "Insurances.NotFound", 
        "Insurance not found");
}

