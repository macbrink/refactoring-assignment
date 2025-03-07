using Insurify.Domain.Customers;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Insurify.Infrastructure.Repositories
{
    /// <summary>
    /// Repository for <see cref="Customer"/> entities.
    /// </summary>
    internal sealed class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        ApplicationDbContext _dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerRepository"/> class.
        /// </summary>
        /// <param name="dbContext">the ApplicationDbContext</param>
        public CustomerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        /// <inheritdoc />
        public async Task<bool> EmailExists(string email)
        {
            var sql = "SELECT COUNT(1) FROM t_customers WHERE cus_email = @Email";
            var count = await _dbContext.Database.ExecuteSqlRawAsync(sql, new SqlParameter("@Email", email));
            return count > 0;
        }
    }
}
