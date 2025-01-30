using Insurify.Domain.Abstractions;

namespace Insurify.Domain.Customers;

public sealed class Customer : Entity
{
    private Customer(Guid id,
        FirstName firstName,
        LastName lastName,
        Email email)
        : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    private Customer()
    {
    }

    public FirstName FirstName { get; private set; } = default!;

    public LastName LastName { get; private set; } = default!;

    public Email Email { get; private set; } = default!;

    public static Result<Customer> Create(
        FirstName firstName,
        LastName lastName,
        Email email)
    {
        var customer = new Customer(Guid.NewGuid(), firstName, lastName, email);
        return Result.Success(customer);
    }

    public void Update(
        FirstName firstName,
        LastName lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
}

