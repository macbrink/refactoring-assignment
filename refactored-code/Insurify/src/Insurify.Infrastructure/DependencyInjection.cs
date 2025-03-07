using Insurify.Application.Abstractions.Data;
using Insurify.Application.Abstractions.Dates;
using Insurify.Application.Abstractions.Elligibility;
using Insurify.Application.Abstractions.Email;
using Insurify.Application.Abstractions.Pricing;
using Insurify.Domain.Abstractions;
using Insurify.Domain.Customers;
using Insurify.Domain.InsurancePolicies;
using Insurify.Domain.Insurances;
using Insurify.Infrastructure.Data;
using Insurify.Infrastructure.Email;
using Insurify.Infrastructure.Repositories;
using Insurify.Infrastructure.Services.BirthDateService;
using Insurify.Infrastructure.Services.ElligibilityServices;
using Insurify.Infrastructure.Services.IdCreatorServices;
using Insurify.Infrastructure.Services.PricingServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Insurify.Infrastructure;

/// <summary>
/// Dependency injection for the infrastructure layer.
/// Adds services to the service collection.
/// - InsuranceRepository
/// - InsurancePolicyRepository
/// - CustomerRepository
/// - InsuranceElligibilityCheckerFactory
/// - JsonIdCreator
/// - PricingServicesFactory
/// - EmailService
/// - UnitOfWork
/// - SqlConnectionFactory
/// - ApplicationDbContext
/// - ISqlConnectionFactory
/// - ICustomerBirthDatService
/// </summary>
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    { 
        services.AddScoped<IInsuranceRepository, InsuranceRepository>();

        services.AddScoped<IInsurancePolicyRepository, InsurancePolicyRepository>();

        services.AddScoped<ICustomerRepository, CustomerRepository>();

        services.AddTransient<IElligibiltyCheckerFactory, InsuranceElligibilityCheckerFactory>();

        services.AddTransient<IIdCreator, JsonIdCreator>();

        services.AddTransient<IPricingServiceFactory, PricingServicesFactory>();

        services.AddTransient<IEmailService, EmailService>();

        services.AddSingleton<ICustomerBirthDateService, BirthDateService>();

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

        var connectionString =
            configuration.GetConnectionString("DefaultConnection") ??
            throw new ArgumentNullException(nameof(configuration));

        services.AddSingleton<ISqlConnectionFactory>(_ => new SqlConnectionFactory(connectionString));

        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

        services.AddScoped<IApplicationDbContext>(sp => sp.GetRequiredService<ApplicationDbContext>());

        return services;
    }
}
