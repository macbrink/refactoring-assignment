using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insurify.Application.Abstractions.Data;
using Insurify.Domain.Abstractions;
using Insurify.Domain.Customers;
using Insurify.Domain.InsurancePolicies;
using Insurify.Domain.Insurances;
using Insurify.Infrastructure.Data;
using Insurify.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Insurify.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            if(string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentException("Connection string is missing", nameof(connectionString));
            }

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<IInsuranceRepository, InsuranceRepository>();

            services.AddScoped<IInsurancePolicyRepository, InsurancePolicyRepository>();

            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

            services.AddSingleton<ISqlConnectionFactory>(_ => new SqlConnectionFactory(connectionString));
            return services;
        }
    }
}
