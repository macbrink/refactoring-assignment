﻿namespace Insurify.Domain.Customers;

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
    Task<Customer> GetByIdAsync(int customerId, CancellationToken cancellationToken);

    /// <summary>
    /// Get a customer by their email
    /// </summary>
    /// <param name="email">The email of the customer</param>
    /// <param name="cancellationToken">A cancellation token</param>
    /// <returns>The customer</returns>
    Task<Customer> GetCustomerByEmailAsync(string email, CancellationToken cancellationToken);
    
}
