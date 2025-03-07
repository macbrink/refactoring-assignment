using Insurify.Domain.Customers;
using Insurify.Domain.Shared;

namespace Insurify.Domain.UnitTests.Customers
{
    internal static class CustomerData
    {
        public static readonly Name FirstName = new("FirstName");
        public static readonly Name LastName = new("LastName");
        public static readonly Email Email = new("test@test.now");
        public static readonly DateOnly BirthDate = new(2000, 1, 1);
        public static readonly Address Address = new("USA", "MA", "02110", "Boston", "123 Main St");
        public static readonly bool HasSecurityCertificate = true;
    }
}
