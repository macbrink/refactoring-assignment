using Insurify.Application.Abstractions.Messaging;

namespace Insurify.Application.Customers.Add;

/// <summary>
/// Command to add a new customer.
/// </summary>
/// <param name="FirstName">First Name</param>
/// <param name="LastName">First Name</param>
/// <param name="Email">EMail</param>
/// <param name="BirthDate">Birth Date</param>
public sealed record AddCustomerCommand(
    string FirstName,
    string LastName,
    string Email,
    DateOnly BirthDate
    ) : ICommand;