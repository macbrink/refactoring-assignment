using Insurify.Application.Abstractions.Data;
using Insurify.Application.Exceptions;
using Insurify.Domain.Abstractions;
using Insurify.Domain.Customers;
using Insurify.Domain.InsurancePolicies;
using Insurify.Domain.Insurances;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Insurify.Infrastructure;

/// <summary>
/// The application db context
/// </summary>
public class ApplicationDbContext : DbContext, IUnitOfWork, IApplicationDbContext
{
    private readonly IPublisher _publisher;

    /// <summary>
    /// Constructor for the application db context
    /// </summary>
    /// <param name="options">Options to set up this context</param>
    /// <param name="publisher">A publisher to send events</param>
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IPublisher publisher)
        : base(options)
    {
        _publisher = publisher;
    }

    /// <summary>
    /// The insurances
    /// </summary>
    public DbSet<Insurance> Insurances { get; private set; }

    /// <summary>
    /// The insurance policies
    /// </summary>
    public DbSet<InsurancePolicy> InsurancePolicies { get; private set;  }

    /// <summary>
    /// The customers
    /// </summary>
    public DbSet<Customer> Customers { get; private set; }

    /// <summary>
    /// On model creating
    /// </summary>
    /// <param name="modelBuilder">The dBConetxt model builder</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    /// <summary>
    /// Save changes and publish domain events
    /// </summary>
    /// <param name="cancellationToken">a CancellationToken</param>
    /// <returns>Rows affected</returns>
    /// <exception cref="ConcurrencyException"></exception>
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var result = await base.SaveChangesAsync(cancellationToken);

            await PublishDomainEventsAsync();

            return result;
        }
        catch(DbUpdateConcurrencyException ex)
        {
            throw new ConcurrencyException("Concurrency exception occurred.", ex);
        }
    }

    private async Task PublishDomainEventsAsync()
    {
        var domainEvents = ChangeTracker
            .Entries<Entity>()
            .Select(entry => entry.Entity)
            .SelectMany(entity =>
            {
                var domainEvents = entity.GetDomainEvents();

                entity.ClearDomainEvents();

                return domainEvents;
            })
            .ToList();

        foreach(var domainEvent in domainEvents)
        {
            await _publisher.Publish(domainEvent);
        }
    }
}
