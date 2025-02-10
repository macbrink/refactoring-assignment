using Insurify.Domain.Abstractions;
using Insurify.Domain.Customers.Events;

namespace Insurify.Domain.Customers;

/// <summary>
/// Model representing a customer.
/// </summary>
public sealed class Customer : Entity
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Customer"/> class.
    /// </summary>
    /// <param name="id">The Id for the Customer</param>
    /// <param name="firstName">Customer's first name</param>
    /// <param name="lastName">Customer's last name</param>
    /// <param name="email">Customer's email-address</param>
    /// <param name="birthDate">Customer's burth date</param>
    private Customer(Guid id,
        FirstName firstName,
        LastName lastName,
        DateOnly birthDate,
        Email email
        )
        : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
        Email = email;
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
    public FirstName FirstName { get; private set; } = default!;

    /// <summary>
    /// Gets the last name of the customer.
    /// </summary>
    public LastName LastName { get; private set; } = default!;

    /// <summary>
    /// Gets the email of the customer.
    /// </summary>
    public Email Email { get; private set; } = default!;

    /// <summary>
    /// Gets the birth date of the customer.
    /// </summary>
    public DateOnly BirthDate { get; private set; } = DateOnly.MinValue;

    /// <summary>
    /// Creates a new instance of the <see cref="Customer"/> class.
    /// </summary>
    /// <param name="firstName">Customer's first name</param>
    /// <param name="lastName">Customer's last name</param>
    /// <param name="email">Customer's last name</param>
    /// <param name="birthDate">Customer's burth date</param>
    /// <returns>Customer Instance</returns>
    public static Result<Customer> Create(
        FirstName firstName,
        LastName lastName,
        DateOnly birthDate,
        Email email)
    {
        var customer = new Customer(Guid.NewGuid(), firstName, lastName, birthDate, email);
        return Result.Success(customer);
    }

    /// <summary>
    /// Updates the name of the customer.
    /// </summary>
    /// <param name="firstName">Custoimer's first name</param>
    /// <param name="lastName">Customer's last name</param>
    /// <returns><see cref="Result"/></returns>
    public Result UpdateName(
        FirstName firstName,
        LastName lastName)
    {
        FirstName = firstName;
        LastName = lastName;
        RaiseDomainEvent(new CustomerNammeChangedDomainEvent(Id));
        return Result.Success();
    }
}

