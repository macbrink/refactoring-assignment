namespace Insurify.Domain.Customers;

/// <summary>
/// Represents an address.
/// </summary>
/// <param name="Country">the Country</param>
/// <param name="State">the State</param>
/// <param name="PostalCode">the Postal Code or ZIP Code</param>
/// <param name="City">the City</param>
/// <param name="Street">the Street and Number</param>
public record Address(
    /// <summary>
    /// The Address Country.
    /// </summary>  
    string Country,

    /// <summary>
    /// The Address State
    /// </summary>
    string State,

    /// <summary>
    /// The Address Postal Code or ZIP Code
    /// </summary>
    string PostalCode,

    /// <summary>
    /// The Address City
    /// </summary>
    string City,

    /// <summary>
    /// The Address Street and Number
    /// </summary>
    string Street
);