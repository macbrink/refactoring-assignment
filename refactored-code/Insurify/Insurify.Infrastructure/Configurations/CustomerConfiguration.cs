using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Insurify.Domain.Customers;

namespace Insurify.Infrastructure.Configurations;

/// <summary>
/// Configuration for the Customer entity.
/// </summary>
internal sealed class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    /// <summary>
    /// Configure the Customer entity.
    /// </summary>
    /// <param name="builder">EF EntityTypeBuilder</param>
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("t_customers");

        builder.HasKey(customer => customer.Id);

        builder.Property(customer => customer.Id)
            .ValueGeneratedNever();

        builder.OwnsOne(customer => customer.Address, address =>
        {
            address.Property(a => a.Street).HasColumnName("Street");
            address.Property(a => a.City).HasColumnName("City");
            address.Property(a => a.State).HasColumnName("State");
            address.Property(a => a.PostalCode).HasColumnName("ZipCode");
        });

        builder.Property(customer => customer.FirstName)
            .HasMaxLength(40)
            .HasColumnName("FirstName")
            .HasConversion(Firstname => Firstname.Value, value => new FirstName(value));

        builder.Property(customer => customer.LastName)
            .HasMaxLength(40)
            .HasColumnName("LastName")
            .HasConversion(Firstname => Firstname.Value, value => new LastName(value));

        builder.Property(customer => customer.Email)
            .HasMaxLength(254)
            .HasColumnName("Email")
            .HasConversion(email => email.Value, value => new Domain.Customers.Email(value));

        builder.HasIndex(customer => customer.Email).IsUnique();
    }
}

