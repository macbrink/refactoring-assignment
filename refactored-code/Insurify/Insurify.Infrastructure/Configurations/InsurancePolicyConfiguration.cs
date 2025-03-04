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

        builder.Property(insurancePolicy => insurancePolicy.Id)
            .ValueGeneratedNever();

        builder.Property(insurancePolicy => insurancePolicy.Id)
            .HasColumnName("inp_pk");

        builder.HasOne<Insurance>()
            .WithMany()
            .HasForeignKey(insurancePolicy => insurancePolicy.InsuranceId);

        builder.Property(insurancePolicy => insurancePolicy.InsuranceId)
            .HasColumnName("inp_ins_id");

        builder.HasOne<Customer>()
            .WithMany()
            .HasForeignKey(insurancePolicy => insurancePolicy.SubscriberId);

        builder.Property(insurancePolicy => insurancePolicy.SubscriberId)
            .HasColumnName("inp_cus_id");

        builder.OwnsOne(insurancePolicy => insurancePolicy.Fee, feeBuilder =>
        {
            feeBuilder.Property(money => money.Amount)
                .HasPrecision(18, 4)
                .HasColumnName("inp_feeamount");

            feeBuilder.Property(money => money.Currency)
                .HasConversion(currency => currency.Code, code => Currency.FromCode(code))
                .HasColumnName("inp_feecurrency");
        });

        builder.OwnsOne(insurancePolicy => insurancePolicy.InsuredAmount, insuredAmountBuilder =>
        {
            insuredAmountBuilder.Property(money => money.Amount)
                .HasPrecision(18, 4)
                .HasColumnName("inp_insuredamount");

            insuredAmountBuilder.Property(money => money.Currency)
                .HasConversion(currency => currency.Code, code => Currency.FromCode(code))
                .HasColumnName("inp_insuredcurrency");
        });
    }
}
