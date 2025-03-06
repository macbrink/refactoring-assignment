namespace Insurify.Domain.Customers;

/// <summary>
/// Repository for managing customers
/// </summary>
public interface ICustomerRepository
{
    /// <summary>
    /// Get a customer by their id
    /// </summary>
    /// <param name="customerId">The id of the customer</param>
    /// <param name="cancellationToken">A cancellation token</param>
    /// <returns>The customer</returns>
    Task<Customer?> GetByIdAsync(int customerId, CancellationToken cancellationToken);

    /// <summary>
    /// Add a customer to the repository
    /// </summary>
    /// <param name="customer">a Customer instance</param>
    /// <param name="cancellationToken">A CancellationToken</param>
    void Add(Customer customer, CancellationToken cancellationToken);

    /// <summary>
    /// Check if an email already exists in the repository
    /// </summary>
    /// <param name="email">Email Adress</param>
    /// <param name="cancellationToken">A CancellationToken</param>
    /// <returns></returns>
    Task<bool> EmailExists(string email, CancellationToken cancellationToken);
}
