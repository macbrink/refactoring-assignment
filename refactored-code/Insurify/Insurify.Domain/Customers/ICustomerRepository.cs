namespace Insurify.Domain.Customers;

public interface ICustomerRepository
{
    Task<Customer> GetById(Guid id, CancellationToken cancellationToken = default);

    void Add(Customer customer);
}
