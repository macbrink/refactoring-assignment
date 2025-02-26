using Insurify.Domain.Customers;

namespace Insurify.Infrastructure.Repositories
{
    /// <summary>
    /// Repository for <see cref="Customer"/> entities.
    /// </summary>
    internal sealed class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerRepository"/> class.
        /// </summary>
        /// <param name="dbContext">the ApplicationDbContext</param>
        public CustomerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
