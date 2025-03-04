using Insurify.Domain.Abstractions;
using Insurify.Domain.Customers.Events;
using Insurify.Domain.Shared;

namespace Insurify.Domain.Customers;

/// <summary>
/// Model representing a customer.
/// </summary>
public sealed class Customer : Entity
{
    private readonly Random random = new Random();

    /// <summary>
    /// Initializes a new instance of the <see cref="Customer"/> class.
    /// </summary>
    /// <param name="idCreator">The   external Creator for the Id</param>
    /// <param name="firstName">Customer's first name</param>
    /// <param name="lastName">Customer's last name</param>
    /// <param name="email">Customer's email-address</param>
    /// <param name="birthDate">Customer's burth date</param>
    private Customer(IIdCreator idCreator,
        Name firstName,
        Name lastName,
        DateOnly birthDate,
        Email email
        )
        : base(idCreator)
    {
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
        Email = email;

        Status = CustomerStatus.Created;

        // Randomly assign a security certificate to keep class simle
        // For real-world scenario, this should be handled by a service
        HasSecurityCertificate = random.Next(2) == 0;
    }

    /// <summary>
    /// Empty constructor for EF Core.
    /// </summary>
    private Customer()
    {
    }

    /// <summary>
    /// Gets the first name of the customer.
    /// </summary>
    public Name FirstName { get; private set; } = default!;

    /// <summary>
    /// Gets the last name of the customer.
    /// </summary>
    public Name LastName { get; private set; } = default!;

    /// <summary>
    /// Gets the email of the customer.
    /// </summary>
    public Email Email { get; private set; } = default!;

    /// <summary>
    /// Gets the birth date of the customer.
    /// </summary>
    public DateOnly BirthDate { get; private set; } = DateOnly.MinValue;

    /// <summary>
    /// Gets the address of the customer.
    /// </summary>
    public Address Address { get; private set; } = default!;

    /// <summary>
    /// Gets the security certificate of the customer.
    /// </summary>
    public bool HasSecurityCertificate { get; private set; }

    /// <summary>
    /// Gets the status of the customer.
    /// </summary>
    public CustomerStatus Status { get; private set; } 

    /// <summary>
    /// Creates a new instance of the <see cref="Customer"/> class.
    /// </summary>
    /// <param name="idCreator">Creator for a new Id</param>
    /// <param name="firstName">Customer's first name</param>
    /// <param name="lastName">Customer's last name</param>
    /// <param name="email">Customer's last name</param>
    /// <param name="birthDate">Customer's burth date</param>
    /// <returns>Customer Instance</returns>
    public static Result<Customer> Create(
        IIdCreator idCreator,
        Name firstName,
        Name lastName,
        DateOnly birthDate,
        Email email)
    {
        var customer = new Customer(
            idCreator, 
            firstName, 
            lastName, 
            birthDate, 
            email);
        return Result.Success(customer);
    }

    /// <summary>
    /// Updates the name of the customer.
    /// </summary>
    /// <param name="firstName">Custoimer's first name</param>
    /// <param name="lastName">Customer's last name</param>
    /// <returns><see cref="Result"/></returns>
    public Result UpdateName(
       Name firstName,
       Name lastName)
    {
        FirstName = firstName;
        LastName = lastName;
        RaiseDomainEvent(new CustomerNammeChangedDomainEvent(Id));
        return Result.Success();
    }
}

