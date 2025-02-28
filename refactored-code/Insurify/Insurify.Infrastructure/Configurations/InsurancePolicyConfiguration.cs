using Insurify.Domain.Customers;
using Insurify.Domain.InsurancePolicies;
using Insurify.Domain.Insurances;
using Insurify.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insurify.Infrastructure.Configurations;

/// <summary>
/// Configuration for the InsurancePolicy entity.
/// </summary>
internal sealed class InsurancePolicyConfiguration : IEntityTypeConfiguration<InsurancePolicy>
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
            feeBuilder.Property(money => money.Amount)
                .HasPrecision(18, 4)
                .HasColumnName("FeeAmount");

            feeBuilder.Property(money => money.Currency)
                .HasConversion(currency => currency.Code, code => Currency.FromCode(code))
                .HasColumnName("FeeCurrency");
        });

        builder.OwnsOne(insurancePolicy => insurancePolicy.InsuredAmount, insuredAmountBuilder =>
        {
            insuredAmountBuilder.Property(money => money.Amount)
                .HasPrecision(18, 4)
                .HasColumnName("InsuredAmount");

            insuredAmountBuilder.Property(money => money.Currency)
                .HasConversion(currency => currency.Code, code => Currency.FromCode(code))
                .HasColumnName("InsuredCurrency");
        });
    }
}
