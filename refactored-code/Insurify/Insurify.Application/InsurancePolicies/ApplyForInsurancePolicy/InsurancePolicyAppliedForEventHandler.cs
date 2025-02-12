using Insurify.Domain.InsurancePolicies;
using Insurify.Application.Abstractions.Email;
using Insurify.Domain.InsurancePolicies.Events;
using Insurify.Domain.Customers;
using MediatR;

namespace Insurify.Application.InsurancePolicies.ApplyForInsurancePolicy;

/// <summary>
/// Command To be issued after an insurance policy has been applied for.
/// </summary>
internal sealed class InsurancePolicyAppliedForEventHandler : INotificationHandler<InsurancePolicyAppliedForDomainEvent>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IInsurancePolicyRepository _insurancePolicyRepository;
    private readonly IEmailService _emailservice;

    /// <summary>
    /// Constructor for the handler
    /// </summary>
    /// <param name="customerRepository">the customer repository</param>
    /// <param name="insurancePolicyRepository">the insurance policy repository</param>
    /// <param name="emailservice">the email service</param>
    public InsurancePolicyAppliedForEventHandler(
        ICustomerRepository customerRepository,
        IInsurancePolicyRepository insurancePolicyRepository,
        IEmailService emailservice
        )
    {
        _customerRepository = customerRepository;
        _insurancePolicyRepository = insurancePolicyRepository;
        _emailservice = emailservice;
    }

    /// <summary>
    /// Handles the event
    /// </summary>
    /// <param name="notification">the event handled</param>
    /// <param name="cancellationToken">a cancellation token</param>
    public async Task Handle(InsurancePolicyAppliedForDomainEvent notification, CancellationToken cancellationToken)
    {
        var policy = await _insurancePolicyRepository.GetByIdAsync(notification.InsurancePolicyId);
        if(policy == null)
        {
            return;
        }
        var customer = await _customerRepository.GetByIdAsync(policy.SubscriberId);

        if(customer == null)
        {
            return;
        }


        await _emailservice.SendAsync(
            customer.Email, 
            "Policy Applied", 
            "Your policy has been applied for");
    }
}

