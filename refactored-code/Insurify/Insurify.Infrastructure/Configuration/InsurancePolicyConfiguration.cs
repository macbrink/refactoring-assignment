using Insurify.Domain.Customers;
using Insurify.Domain.InsurancePolicies;
using Insurify.Domain.Insurances;
using Insurify.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insurify.Infrastructure.Configuration;

/// <summary>
/// Configuration for the InsurancePolicy entity.
/// </summary>
internal sealed class InsurancePolicyConfiguration
{
    /// <summary>
    /// Configure the InsurancePolicy entity.
    /// </summary>
    /// <param name="builder">EF EntityTypeBuilder</param>
    public void Configure(EntityTypeBuilder<InsurancePolicy> builder)
    {
        builder.ToTable("t_insurancepolicies");

        builder.HasKey(insurancePolicy => insurancePolicy.Id);

        builder.HasOne<Insurance>()
            .WithMany()
            .HasForeignKey(insurancePolicy => insurancePolicy.InsuranceId);


        builder.HasOne<Customer>()
            .WithMany()
            .HasForeignKey(insurancePolicy => insurancePolicy.SubscriberId);

        builder.OwnsOne(insurancePolicy => insurancePolicy.Fee, feeBuilder =>
        {
            feeBuilder.Property(money => money.Currency)
                .HasConversion(currency => currency.Code, code => Currency.FromCode(code));
        });

        builder.OwnsOne(insurancePolicy => insurancePolicy.InsuredAmount, insuredAmountBuilder =>
        {
            insuredAmountBuilder.Property(money => money.Currency)
                .HasConversion(currency => currency.Code, code => Currency.FromCode(code));
        });
    }
}
