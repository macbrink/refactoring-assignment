namespace Insurify.Application.Abstractions.Email;

/// <summary>
/// Interface for the email service
/// </summary>
public interface IEmailService
{
    /// <summary>
    /// Sends an email to a recipient
    /// </summary>
    /// <param name="recipient">Recepient of the email</param>
    /// <param name="subject">Subject of the email</param>
    /// <param name="body">Body of the email</param>
    /// <returns></returns>
    Task SendAsync(Domain.Customers.Email recipient, string subject, string body);
}