using Insurify.Domain.Insurances;
using Insurify.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insurify.Infrastructure.Configurations;

/// <summary>
/// Configuration for the Insurance entity.
/// </summary>
internal sealed class InsuranceConfiguration : IEntityTypeConfiguration<Insurance>
{
    /// <summary>
    /// Configure the Insurance entity.
    /// </summary>
    /// <param name="builder">EF EntityTypeBuilder</param>
    public void Configure(EntityTypeBuilder<Insurance> builder)
    {
        builder.ToTable("t_insurances");

        builder.HasKey(insurance => insurance.Id);

        builder.Property(insurance => insurance.Id)
            .HasColumnName("ins_pk");

        builder.Property(insurance => insurance.Id)
            .ValueGeneratedNever();

        builder.Property(insurance => insurance.Name)
            .HasMaxLength(100)
            .HasColumnName("ins_name")
            .HasConversion(name => name.Value, value => new Name(value));

        builder.Property(insurance => insurance.Description)
            .HasMaxLength(500)
            .HasColumnName("ins_description")
            .HasConversion(description => description.Value, value => new Description(value));

        builder.OwnsOne(insurance => insurance.Price, priceBuilder =>
        {
            priceBuilder.Property(money => money.Amount)
                .HasPrecision(18, 4) 
                .HasColumnName("ins_priceamount");

            priceBuilder.Property(money => money.Currency)
                .HasConversion(currency => currency.Code, code => Currency.FromCode(code))
                .HasColumnName("ins_pricecurrency");
        });
    }
}