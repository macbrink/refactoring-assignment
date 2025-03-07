using Insurify.Application.Abstractions.Messaging;

namespace Insurify.Application.Customers.EmailExists
{
    /// <summary>
    /// Query to check if a customer with the given email exists
    /// </summary>
    /// <param name="Email">The Email Adress to check for</param>
	public sealed record CustomerEmailExistsQuery(
        string Email) : IQuery<bool>;
}
