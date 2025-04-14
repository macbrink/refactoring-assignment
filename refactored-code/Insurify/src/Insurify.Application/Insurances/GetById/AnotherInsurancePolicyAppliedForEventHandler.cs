using Insurify.Domain.InsurancePolicies;
using Insurify.Application.Abstractions.Email;
using Insurify.Domain.InsurancePolicies.Events;
using Insurify.Domain.Customers;
using MediatR;
using Insurify.Domain.Abstractions;
using Insurify.Domain.Insurances;
using Insurify.Application.Abstractions.Elligibility;

namespace Insurify.Application.Insurances.GetById;

/// <summary>
/// Command To be issued after an insurance policy has been applied for.
/// </summary>
internal sealed class AnotherInsurancePolicyAppliedForEventHandler : INotificationHandler<InsurancePolicyAppliedForDomainEvent>
{
    private readonly IInsurancePolicyRepository _insurancePolicyRepository;

    public AnotherInsurancePolicyAppliedForEventHandler(
        IInsurancePolicyRepository insurancePolicyRepository
        )
    {
        _insurancePolicyRepository = insurancePolicyRepository;
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

        Console.WriteLine($"Insurance Policy {policy.Id} Applied For");
    }
}

