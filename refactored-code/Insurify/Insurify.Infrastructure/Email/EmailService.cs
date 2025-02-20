using Insurify.Application.Abstractions.Email;

namespace Insurify.Infrastructure.Email;

internal sealed class EmailService : IEmailService
{
    public Task SendAsync(Domain.Customers.Email recipient, string subject, string body)
    {
        return Task.CompletedTask;
    }
}
