
using Insurify.Domain.Customers;
using Insurify.Domain.InsurancePolicies;
using Insurify.Domain.Insurances;
using Microsoft.EntityFrameworkCore;

namespace Insurify.Application.Abstractions.Data;

/// <summary>
/// Interface for the application db context
/// </summary>
public interface IApplicationDbContext
{
    /// <summary>
    /// The dbset for insurances
    /// </summary>
    DbSet<Insurance> Insurances { get; }

    /// <summary>
    /// The dbset for insurance policies
    /// </summary>
    DbSet<InsurancePolicy> InsurancePolicies { get; }

    /// <summary>
    /// The dbset for customers
    /// </summary>
    DbSet<Customer> Customers { get; }
}
