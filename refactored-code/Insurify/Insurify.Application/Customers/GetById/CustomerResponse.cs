using Insurify.Domain.Customers;

namespace Insurify.Application.Customers.GetById;

/// <summary>
/// Response model for the customer
/// </summary>
public sealed class CustomerResponse
{
    /// <summary>
    /// Gets or sets the Id of the customer
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the first name of the customer
    /// </summary>
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the last name of the customer
    /// </summary>
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the email of the customer
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the birth date of the customer
    /// </summary>
    public DateOnly BirthDate { get; set; } 

    /// <summary>
    /// Gets or sets the country of the customer
    /// </summary>
    public string AddressCountry { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the state of the customer
    /// </summary>
    public string AddressState { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the postal code of the customer
    /// </summary>
    public string AddressPostalCode { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the street of the customer
    /// </summary>
    public string AddressStreet { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets a value indicating whether the customer has a security certificate
    /// </summary>
    public bool HasSecurityCertificate { get; set; }

    /// <summary>
    /// Gets or sets the status of the customer
    /// </summary>
    public CustomerStatus Status { get; set; }
}