using Insurify.Domain.Abstractions;
using Insurify.Domain.Covers.Events;
using Insurify.Domain.Shared;

namespace Insurify.Domain.Covers;

/// <summary>
/// Model representing an insurance policy.
/// </summary>
public class InsurancePolicy : Entity
{
    private InsurancePolicy(
        Guid id, 
        Guid insuranceId, 
        Guid subscriberId, 
        DateTime startDate, 
        Money fee,
        Money insuredAmount,
        CoverStatus status  
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
    public Guid InsuranceId { get; private set; }

    /// <summary>
    /// The subscriber id.
    /// </summary>
    public Guid SubscriberId { get; private set; }

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
    /// <seealso cref="CoverStatus"/>   
    /// </summary>
    public CoverStatus Status { get; private set; }

    /// <summary>
    /// Apply for an insurance policy.
    /// <para>
    /// Creates the policy, and sets the status of the policy to <see cref="CoverStatus.AppliedFor"/>
    /// </para>
    /// <para>
    /// Raises a <see cref="InsurancePolicyAppliedDomainEvent"/> domain event.
    /// </para>
    /// </summary>
    /// <param name="insuranceId">The Id of the insurance.</param>
    /// <param name="subscriberId">The Id of the subscriber.</param>
    /// <param name="startDate">The start date of the policy.</param>
    /// <param name="insuredAmount">The insured amount.</param>
    /// <param name="pricingService">The pricing service to calculate the fee</param>
    /// <returns></returns>
    public static InsurancePolicy Apply(
        Guid insuranceId,
        Guid subscriberId,
        DateTime startDate,
        Money insuredAmount,
        IPricingService pricingService)
    {
        Money fee = pricingService.CalculatePremium(
            insuranceId,
            subscriberId,
            startDate,
            insuredAmount);

        var cover = new InsurancePolicy(
            Guid.NewGuid(),
            insuranceId,
            subscriberId,
            startDate,
            fee,
            insuredAmount ,
            CoverStatus.AppliedFor);

        cover.RaiseDomainEvent(new InsurancePolicyAppliedDomainEvent(cover.Id));

        return cover;
    }

    /// <summary>
    /// Confirm the insurance policy.
    /// <para>
    /// Sets the status of the policy to <see cref="CoverStatus.Confirmed"/>
    /// </para>
    /// <para>
    /// Raises a <see cref="InsurancePolicyrConfirmedDomainEvent"/> domain event.
    /// </para>
    /// </summary>
    /// <returns>A <see cref="Result"/> object</returns>
    public Result Confirm()
    {
        if(Status != CoverStatus.AppliedFor)
        {
            return Result.Failure(CoverErrors.NotAppliedFor);
        }

        Status = CoverStatus.Confirmed;       
        RaiseDomainEvent(new InsurancePolicyrConfirmedDomainEvent(Id));
        return Result.Success();
    }

    /// <summary>
    /// Reject the insurance policy.    
    /// <para>
    /// Sets the status of the policy to <see cref="CoverStatus.Rejected"/>
    /// </para>
    /// <para>
    /// Raises a <see cref="InsurancePolicyRejectedDomainEvent"/> domain event.
    /// </para>
    /// </summary>
    /// <returns>A <see cref="Result"/> object</returns>
    public Result Reject()
    {
        if(Status != CoverStatus.AppliedFor)
        {
            return Result.Failure(CoverErrors.NotAppliedFor);
        }

        Status = CoverStatus.Rejected;

        RaiseDomainEvent(new InsurancePolicyRejectedDomainEvent(Id));

        return Result.Success();
    }

    /// <summary>
    /// Cancels the insurance policy
    /// <para>
    /// Raises a  <see cref="InsurancePolicyCancelledDomainEvent"/> domain event.
    /// </para>
    /// </summary>
    /// <param name="endTime"></param>
    /// <returns></returns>
    public Result Cancel(DateTime endTime)
    {
        if (Status != CoverStatus.Confirmed)
        {
            return Result.Failure(CoverErrors.NotConfirmed);
        }
        Status = CoverStatus.Cancelled;
        EndDate = endTime;
        RaiseDomainEvent(new InsurancePolicyCancelledDomainEvent(Id));
        return Result.Success();
    }

    /// <summary>
    /// Completes the insurance policy
    /// </summary>
    /// <param name="endTime"></param>
    /// <returns></returns>
    public Result Complete(DateTime endTime)
    {
        if (Status != CoverStatus.Confirmed)
        {
            return Result.Failure(CoverErrors.NotConfirmed);
        }
        Status = CoverStatus.Completed;
        EndDate = DateTime.Today;
        RaiseDomainEvent(new InsurancePolicyCompletedDomainEvent(Id));
        return Result.Success();
    }
}

