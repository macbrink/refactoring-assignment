using Insurify.Application.Abstractions.Messaging;

namespace Insurify.Application.Customers.Add;

/// <summary>
/// Command to add a new customer.
/// </summary>
/// <param name="FirstName">First Name</param>
/// <param name="LastName">First Name</param>
/// <param name="Email">EMail</param>
/// <param name="BirthDate">Birth Date</param>
/// <param name="AddressCountry">Country</param>
/// <param name="AddressPostalCode">Postal code</param>
/// <param name="AddressState">State</param>
/// <param name="AddressCity">City</param>
/// <param name="AddressStreet">Street</param>
/// <param name="HasSecurityCertificate">Security Certificate</param>
public sealed record AddCustomerCommand(
    string FirstName,
    string LastName,
    string Email,
    DateOnly BirthDate,
    string AddressCountry,
    string AddressState,
    string AddressPostalCode,
    string AddressCity,
    string AddressStreet,
    bool HasSecurityCertificate
    ) : ICommand;