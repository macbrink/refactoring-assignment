using Insurify.Application.Abstractions.Data;
using Insurify.Domain.Abstractions;
using Insurify.Domain.Customers;
using Insurify.Domain.InsurancePolicies;
using Insurify.Domain.Insurances;
using Microsoft.EntityFrameworkCore;

namespace Insurify.Infrastructure;

public class ApplicationDbContext : DbContext, IUnitOfWork, IApplicationDbContext
{
    public DbSet<Insurance> Insurances { get; private set; }

    public DbSet<InsurancePolicy> InsurancePolicies { get; private set;  }

    public DbSet<Customer> Customers { get; private set; }
}
