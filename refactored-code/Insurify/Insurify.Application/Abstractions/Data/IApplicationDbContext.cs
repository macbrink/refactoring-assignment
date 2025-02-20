
using Insurify.Domain.Customers;
using Insurify.Domain.InsurancePolicies;
using Insurify.Domain.Insurances;
using Microsoft.EntityFrameworkCore;

namespace Insurify.Application.Abstractions.Data;

public interface IApplicationDbContext
{
    DbSet<Insurance> Insurances { get; }

    DbSet<InsurancePolicy> InsurancePolicies { get; }

    DbSet<Customer> Customers { get; }
}
