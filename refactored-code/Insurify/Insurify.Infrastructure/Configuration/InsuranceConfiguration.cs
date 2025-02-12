using Insurify.Domain.Insurances;
using Insurify.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insurify.Infrastructure.Configuration;

public sealed class InsuranceConfiguration : IEntityTypeConfiguration<Insurance>
{   
    public void Configure(EntityTypeBuilder<Insurance> builder)
    {
        builder.ToTable("Insurances");

        builder.HasKey(insurance => insurance.Id);

        builder.Property(insurance => insurance.Name)
            .HasMaxLength(100)
            .HasColumnName("Name")
            .HasConversion(name => name.Value, value => new Name(value));

        builder.Property(insurance => insurance.Description)
            .HasMaxLength(500)
            .HasColumnName("Description")
            .HasConversion(description => description.Value, value => new Description(value));

        builder.OwnsOne(insurance => insurance.Price, priceBuilder =>
        {
            priceBuilder.Property(money => money.Currency)
                .HasConversion(currency => currency.Code, code => Currency.FromCode(code));
        });
    }
}