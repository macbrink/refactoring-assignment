using Insurify.Domain.InsurancePolicies;
using Insurify.Application.Abstractions.Email;
using Insurify.Domain.InsurancePolicies.Events;
using Insurify.Domain.Customers;
using MediatR;
using Insurify.Domain.Abstractions;
using Insurify.Domain.Insurances;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Insurify.Application.Abstractions.Elligibility;

namespace Insurify.Application.InsurancePolicies.ApplyFor;

/// <summary>
/// Command To be issued after an insurance policy has been applied for.
/// </summary>
internal sealed class InsurancePolicyAppliedForEventHandler : INotificationHandler<InsurancePolicyAppliedForDomainEvent>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IInsuranceRepository _insuranceRepository;
    private readonly IInsurancePolicyRepository _insurancePolicyRepository;
    private readonly IElligibiltyCheckerFactory _eligibilityCheckerFactory;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IEmailService _emailservice;

    /// <summary>
    /// Constructor for the handler
    /// </summary>
    /// <param name="customerRepository">the customer repository</param>
    /// <param name="insuranceRepository">IInsuranceRepository instance</param>
    /// <param name="insurancePolicyRepository">the insurance policy repository</param>
    /// <param name="eligibilityCheckerFactory">Factory for Eligibility Checker</param>
    /// <param name="unitOfWork">the unit of work</param>
    /// <param name="emailservice">the email service</param>
    public InsurancePolicyAppliedForEventHandler(
        ICustomerRepository customerRepository,
        IInsuranceRepository insuranceRepository,
        IInsurancePolicyRepository insurancePolicyRepository,
        IElligibiltyCheckerFactory eligibilityCheckerFactory,
        IUnitOfWork unitOfWork,
        IEmailService emailservice
        )
    {
        _customerRepository = customerRepository;
        _insuranceRepository = insuranceRepository;
        _insurancePolicyRepository = insurancePolicyRepository;
        _eligibilityCheckerFactory = eligibilityCheckerFactory;
        _unitOfWork = unitOfWork;
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

        var customer = await _customerRepository.GetByIdAsync(policy.SubscriberId, cancellationToken);

        if (customer == null)
        {
            return;
        }
        var insurance = await _insuranceRepository.GetByIdAsync(policy.InsuranceId, cancellationToken);

        if(insurance ==  null)
        {
            return;
        }

        var insuranceElligibilityChecker = _eligibilityCheckerFactory.GetEligibilityChecker(insurance);

        bool elligible = insuranceElligibilityChecker.IsEligible(
            insurance,
            customer,
            cancellationToken);

        if (elligible)
        {
            policy.Confirm();
        }
        else
        {
            policy.Reject();
        }

        _insurancePolicyRepository.Update(policy);        

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        if (policy.Status == InsurancePolicyStatus.Confirmed)
        {
            await _emailservice.SendAsync(
                customer.Email,
                "Policy Applied",
                "Your policy has been applied for, and has been confirmed");
        }
    }
}

