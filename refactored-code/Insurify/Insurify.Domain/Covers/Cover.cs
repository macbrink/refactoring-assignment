using Insurify.Domain.Abstractions;
using Insurify.Domain.Covers.Events;
using Insurify.Domain.Insurances;
using Insurify.Domain.Shared;

namespace Insurify.Domain.Covers;

public class Cover : Entity
{
    private Cover(
        Guid id, 
        Guid insuranceId, 
        Guid customerId, 
        DateTime startDate, 
        Money premium,
        CoverStatus status,
        DateTime createdOnUtc        
        )
        : base(id)
    {
        InsuranceId = insuranceId;
        CustomerId = customerId;
        StartDate = startDate;
        Premium = premium;
        Status = status;
        CreatedOnUtc = createdOnUtc;
    }

    private Cover()
    {
    }

    public Guid InsuranceId { get; private set; }

    public Guid CustomerId { get; private set; }

    public DateTime StartDate { get; private set; }

    public Money Premium { get; private set; } = default!;

    public DateTime CreatedOnUtc { get; private set; }

    public DateTime? ConfirmedOnUtc { get; private set; }

    public DateTime? RejectedOnUtc { get; private set; }

    public DateTime? CompletedOnUtc { get; private set; }

    public DateTime? CancelledOnUtc { get; private set; }

    public CoverStatus Status { get; private set; }

    public static Cover Apply(
        Insurance insurance,
        Guid customerId,
        DateTime startDate,
        DateTime utcNow,
        IPricingService pricingService)
    {
        Money premium = pricingService.CalculatePremium(insurance, customerId, startDate);

        var cover = new Cover(
            Guid.NewGuid(),
            insurance.Id,
            customerId,
            startDate,
            premium,
            CoverStatus.AppliedFor,
            utcNow);

        cover.RaiseDomainEvent(new CoverAppliedDomainEvent(cover.Id);

        return cover;
    }

    public Result Confirm(DateTime utcNow)
    {
        if(Status != CoverStatus.AppliedFor)
        {
            return Result.Failure(CoverErrors.NotAppliedFor);
        }

        Status = CoverStatus.Confirmed;
        ConfirmedOnUtc = utcNow;
        RaiseDomainEvent(new CoverConfirmedDomainEvent(Id));
        return Result.Success();
    }

    public Result Reject(DateTime utcNow)
    {
        if(Status != CoverStatus.AppliedFor)
        {
            return Result.Failure(CoverErrors.NotAppliedFor);
        }

        Status = CoverStatus.Rejected;
        RejectedOnUtc = utcNow;

        RaiseDomainEvent(new CoverRejectedDomainEvent(Id));

        return Result.Success();
    }
}

