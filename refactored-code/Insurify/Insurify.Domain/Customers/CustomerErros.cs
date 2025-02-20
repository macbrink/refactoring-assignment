using Insurify.Domain.Abstractions;

namespace Insurify.Domain.Customers;

/// <summary>
/// Represents errors that can occur with customers.
/// </summary>
public static class CustomerErros
{
    /// <summary>
    /// Represents an error when the customer is not found.
    /// </summary>
    public static readonly Error NotFound = new(
        "Customers.NotFound",
        "Customer not found");
}

