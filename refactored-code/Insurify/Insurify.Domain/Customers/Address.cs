namespace Insurify.Domain.Customers;

/// <summary>
/// Represents an address.
/// </summary>
/// <param name="Country">the Country</param>
/// <param name="PostalCode">the Postal Code or ZIP Code</param>
/// <param name="City">the City</param>
/// <param name="Street">the Street and Number</param>
public record Address(
    string Country,
    string State,
    string PostalCode,
    string City,
    string Street);