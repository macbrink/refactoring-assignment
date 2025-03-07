using FluentAssertions;
using Insurify.Domain.Customers;

namespace Insurify.Domain.UnitTests.Customers;

public class CustomerTest
{
    [Fact]
    public void Create_Should_SetPropertyValues()
    {
        // Act
        var result= Customer.Create(
            new CustomerIdCreator(),
            CustomerData.FirstName,
            CustomerData.LastName,
            CustomerData.BirthDate,
            CustomerData.Email,
            CustomerData.Address,
            CustomerData.HasSecurityCertificate
        );

        // Assert Result
        result.IsSuccess.Should().BeTrue();

        Customer customer = result.Value;

        // Assert customer properties
        customer.FirstName.Should().Be(CustomerData.FirstName);
        customer.LastName.Should().Be(CustomerData.LastName);
        customer.BirthDate.Should().Be(CustomerData.BirthDate);
        customer.Email.Should().Be(CustomerData.Email);
        customer.Address.Should().Be(CustomerData.Address);
        customer.HasSecurityCertificate.Should().Be(CustomerData.HasSecurityCertificate);
    }
}
