using Insurify.Domain.Abstractions;
using Insurify.Domain.Customers;
using Insurify.Domain.InsurancePolicies.Events;
using Insurify.Domain.Insurances;
using Insurify.Domain.Shared;

namespace Insurify.Domain.InsurancePolicies;

/// <summary>
/// Model representing an insurance policy.
/// </summary>
public class InsurancePolicy : Entity
{
    private InsurancePolicy(
        int id,
        int insuranceId,
        int subscriberId,
        DateTime startDate,
        Money fee,
        Money insuredAmount,
        InsurancePolicyStatus status
        )
        : base(id)
    {
        InsuranceId = insuranceId;
        SubscriberId = subscriberId;
        StartDate = startDate;
        InsuredAmount = insuredAmount;
        Fee = fee;
        Status = status;
    }

    private InsurancePolicy()
    {
    }

    /// <summary>
    /// The insurance id.
    /// </summary>
    public int InsuranceId { get; private set; }

    /// <summary>
    /// The subscriber id.
    /// </summary>
    public int SubscriberId { get; private set; }

    /// <summary>
    /// The start date of the policy.
    /// </summary>
    public DateTime StartDate { get; private set; }

    /// <summary>
    /// The insured amount.
    /// </summary>
    public Money InsuredAmount { get; private set; } = Money.Zero();

    /// <summary>
    /// The fee of the policy.
    /// </summary>
    public Money Fee { get; private set; } = default!;

    /// <summary>
    /// The end date of the policy.
    /// </summary>
    public DateTime? EndDate { get; private set; }

    /// <summary>
    /// The status of the policy.
    /// <seealso cref="InsurancePolicyStatus"/>   
    /// </summary>
    public InsurancePolicyStatus Status { get; private set; }

    /// <summary>
    /// ApplyFor for an insurance policy.
    /// <para>
    /// Creates the policy, and sets the status of the policy to <see cref="InsurancePolicyStatus.AppliedFor"/>
    /// </para>
    /// <para>
    /// Raises a <see cref="InsurancePolicyAppliedForDomainEvent"/> domain event.
    /// </para>
    /// </summary>
    /// <param name="idCreator">Creator for a new Id</param>
    /// <param name="insurance">The Id of the insurance.</param>
    /// <param name="subscriber">The Id of the subscriber.</param>
    /// <param name="startDate">The start date of the policy.</param>
    /// <param name="insuredAmount">The insured amount.</param>
    /// <param name="pricingService">The pricing service to calculate the fee</param>
    /// <returns>An InsurancePolicy instance</returns>
    public static InsurancePolicy ApplyFor(
        IIdCreator idCreator,
        Insurance insurance,
        Customer subscriber,
        DateTime startDate,
        Money insuredAmount,
        IPricingService pricingService)
    {
        Money fee = pricingService.CalculatePremium(
            insurance,
            subscriber,
            startDate,
            insuredAmount
            );

        var insurancePolicy = new InsurancePolicy(
            idCreator.CreateId().Result,
            insurance.Id,
            subscriber.Id,
            startDate,
            fee,
            insuredAmount,
            InsurancePolicyStatus.AppliedFor);

        insurancePolicy.RaiseDomainEvent(new InsurancePolicyAppliedForDomainEvent(insurancePolicy.Id));

        return insurancePolicy;
    }

    /// <summary>
    /// Confirm the insurance policy.
    /// <para>
    /// Sets the status of the policy to <see cref="InsurancePolicyStatus.Confirmed"/>
    /// </para>
    /// <para>
    /// Raises a <see cref="InsurancePolicyrConfirmedDomainEvent"/> domain event.
    /// </para>
    /// </summary>
    /// <returns>A <see cref="Result"/> object</returns>
    public Result Confirm()
    {
        if(Status != InsurancePolicyStatus.AppliedFor)
        {
            return Result.Failure(InsurancePoliciesErrors.NotAppliedFor);
        }

        Status = InsurancePolicyStatus.Confirmed;
        RaiseDomainEvent(new InsurancePolicyrConfirmedDomainEvent(Id));
        return Result.Success();
    }

    /// <summary>
    /// Reject the insurance policy.    
    /// <para>
    /// Sets the status of the policy to <see cref="InsurancePolicyStatus.Rejected"/>
    /// </para>
    /// <para>
    /// Raises a <see cref="InsurancePolicyRejectedDomainEvent"/> domain event.
    /// </para>
    /// </summary>
    /// <returns>A <see cref="Result"/> object</returns>
    public Result Reject()
    {
        if(Status != InsurancePolicyStatus.AppliedFor)
        {
            return Result.Failure(InsurancePoliciesErrors.NotAppliedFor);
        }

        Status = InsurancePolicyStatus.Rejected;
        RaiseDomainEvent(new InsurancePolicyRejectedDomainEvent(Id));
        return Result.Success();
    }

    /// <summary>
    /// Cancels the insurance policy
    /// <para>
    /// Sets the policy status to <see cref="InsurancePolicyStatus.Cancelled"/>
    /// </para>
    /// <para>
    /// Raises a  <see cref="InsurancePolicyCancelledDomainEvent"/> domain event.
    /// </para>
    /// <para>
    /// Sets the policy end date to the cancellation date.
    /// </para>
    /// </summary>
    /// <param name="cancellationDate"></param>
    /// <returns>>A <see cref="Result"/> object</returns>
    public Result Cancel(DateTime cancellationDate)
    {
        if(Status != InsurancePolicyStatus.Confirmed)
        {
            return Result.Failure(InsurancePoliciesErrors.NotConfirmed);
        }
        Status = InsurancePolicyStatus.Cancelled;
        EndDate = cancellationDate;
        RaiseDomainEvent(new InsurancePolicyCancelledDomainEvent(Id));
        return Result.Success();
    }

    /// <summary>
    /// Completes the insurance policy
    /// <para>
    /// Sets the policy status to <see cref="InsurancePolicyStatus.Completed"/>
    /// </para>
    /// <para>
    /// Raises a  <see cref="InsurancePolicyCompletedDomainEvent"/> domain event.
    /// </para>
    /// <para>
    /// Sets the policy end date to the complete date.
    /// </para>
    /// </summary>
    /// <param name="endTime"></param>
    /// <returns>A <see cref="Result"/> object</returns>
    public Result Complete(DateTime endTime)
    {
        if(Status != InsurancePolicyStatus.Confirmed)
        {
            return Result.Failure(InsurancePoliciesErrors.NotConfirmed);
        }
        Status = InsurancePolicyStatus.Completed;
        EndDate = endTime;
        RaiseDomainEvent(new InsurancePolicyCompletedDomainEvent(Id));
        return Result.Success();
    }

    /// <summary>
    /// Updates the fee of the policy
    /// </summary>
    /// <param name="pricingService">The PricingService for the Insurance this policy belongs to</param>
    /// <returns>A <see cref="Result"/> object</returns>
    public Result UpdateFee(IPricingService pricingService)
    {
        if(Status != InsurancePolicyStatus.Confirmed)
        {
            return Result.Failure(InsurancePoliciesErrors.NotConfirmed);
        }
        Fee = pricingService.CalculatePremium(
            InsuranceId,
            SubscriberId,
            StartDate,
            InsuredAmount);
        return Result.Success();
    }
}

