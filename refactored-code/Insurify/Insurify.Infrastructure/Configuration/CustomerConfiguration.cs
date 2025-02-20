using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Insurify.Domain.Customers;

namespace Insurify.Infrastructure.Configuration;

/// <summary>
/// Configuration for the Customer entity.
/// </summary>
internal sealed class CustomerConfiguration
{
    /// <summary>
    /// Configure the Customer entity.
    /// </summary>
    /// <param name="builder">EF EntityTypeBuilder</param>
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("t-customers");

        builder.HasKey(customer => customer.Id);

        builder.HasOne(customer => customer.Address);

        builder.Property(customer => customer.FirstName)
            .HasMaxLength(40)
            .HasColumnName("Name")
            .HasConversion(Firstname => Firstname.Value, value => new FirstName(value));

        builder.Property(customer => customer.LastName)
            .HasMaxLength(40)
            .HasColumnName("Name")
            .HasConversion(Firstname => Firstname.Value, value => new LastName(value));

        builder.Property(customer => customer.Email)
            .HasMaxLength(254)
            .HasColumnName("Email")
            .HasConversion(email => email.Value, value => new Domain.Customers.Email(value));

        builder.HasIndex(customer => customer.Email).IsUnique();
    }
}

