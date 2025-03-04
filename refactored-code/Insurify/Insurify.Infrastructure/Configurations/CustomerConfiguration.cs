using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Insurify.Domain.Customers;
using Insurify.Domain.Shared;

namespace Insurify.Infrastructure.Configurations;

/// <summary>
/// Configuration for the Customer entity.
/// </summary>
internal sealed class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    /// <summary>
    /// Configure the Customer entity.
    /// </summary>
    /// <param name="builder">Entity Framework <see cref="EntityTypeBuilder{TEntity}"></param>
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("t_customers");

        builder.HasKey(customer => customer.Id);

        builder.Property(customer => customer.Id)
            .HasColumnName("cus_pk");

        builder.Property(customer => customer.Id)
            .ValueGeneratedNever();

        builder.OwnsOne(customer => customer.Address, address =>
        {
            address.Property(a => a.Street).HasColumnName("cus_street");
            address.Property(a => a.City).HasColumnName("cus_city");
            address.Property(a => a.State).HasColumnName("cus_state");
            address.Property(a => a.PostalCode).HasColumnName("cus_postalcode");
        });

        builder.Property(customer => customer.FirstName)
            .HasMaxLength(40)
            .HasColumnName("cus_firstname")
            .HasConversion(Firstname => Firstname.Value, value => new Name(value));

        builder.Property(customer => customer.LastName)
            .HasMaxLength(40)
            .HasColumnName("cus_lastname")
            .HasConversion(Firstname => Firstname.Value, value => new Name(value));

        builder.Property(customer => customer.Email)
            .HasMaxLength(254)
            .HasColumnName("cus_email")
            .HasConversion(email => email.Value, value => new Domain.Customers.Email(value));

        builder.HasIndex(customer => customer.Email).IsUnique();
    }
}

