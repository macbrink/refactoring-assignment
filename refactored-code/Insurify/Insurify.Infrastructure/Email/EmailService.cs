using Insurify.Application.Abstractions.Email;

namespace Insurify.Infrastructure.Email;

/// <summary>
/// Implements IEmailService
/// </summary>
internal sealed class EmailService : IEmailService
{
    /// <summary>
    /// Sends an email to a recipient
    /// </summary>
    /// <param name="recipient">The email recipient</param>
    /// <param name="subject">The email subject</param>
    /// <param name="body">The email body</param>
    /// <returns></returns>
    public Task SendAsync(Domain.Customers.Email recipient, string subject, string body)
    {
        return Task.CompletedTask;
    }
}
