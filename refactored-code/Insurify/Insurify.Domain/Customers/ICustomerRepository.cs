namespace Insurify.Domain.Customers;

/// <summary>
/// Repository for managing customers
/// </summary>
public interface ICustomerRepository
{
    /// <summary>
    /// Get a customer by their id
    /// </summary>
    /// <param name="id">Customer's Id</param>
    /// <param name="cancellationToken">a canncellation taken</param>
    /// <returns></returns>
    Task<Customer> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Add a new customer
    /// </summary>
    /// <param name="customer">a Customer object</param>
    void Add(Customer customer);
}
