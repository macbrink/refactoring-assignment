﻿using Insurify.Application.Abstractions.Data;
using Insurify.Application.Abstractions.Elligibility;
using Insurify.Application.Abstractions.Pricing;
using Insurify.Domain.Abstractions;
using Insurify.Domain.Customers;
using Insurify.Domain.InsurancePolicies;
using Insurify.Domain.Insurances;
using Insurify.Infrastructure.Data;
using Insurify.Infrastructure.Repositories;
using Insurify.Infrastructure.Services.ElligibilityServices;
using Insurify.Infrastructure.Services.IdCreatorServices;
using Insurify.Infrastructure.Services.PricingServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Insurify.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        var connectionString = 
            configuration.GetConnectionString("DefaultConnection") ??
            throw new ArgumentException("Connection string is missing", nameof(configuration));

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IInsuranceRepository, InsuranceRepository>();

        services.AddScoped<IInsurancePolicyRepository, InsurancePolicyRepository>();

        services.AddScoped<ICustomerRepository, CustomerRepository>();

        services.AddTransient<IElligibiltyCheckerFactory, InsuranceElligibilityCheckerFactory>();

        services.AddTransient<IIdCreator, JsonIdCreator>();

        services.AddTransient<IPricingServiceFactory, PricingServicesFactory>();

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

        services.AddSingleton<ISqlConnectionFactory>(_ => new SqlConnectionFactory(connectionString));

        return services;
    }
}
