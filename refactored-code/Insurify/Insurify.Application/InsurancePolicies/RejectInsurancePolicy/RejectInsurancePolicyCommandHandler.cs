using Insurify.Application.Abstractions.Messaging;
using Insurify.Domain.Abstractions;
using Insurify.Domain.InsurancePolicies;

namespace Insurify.Application.InsurancePolicies.RejectInsurancePolicy;

/// <summary>
/// Command handler for rejecting an insurance policy.
/// </summary>
public class RejectInsurancePolicyCommandHandler : ICommandHandler<RejectInsurancePolicyCommand>
{
    private readonly IInsurancePolicyRepository _insurancePolicyRepository;
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// Constructor for the handler.
    /// </summary>
    /// <param name="insurancePolicyRepository">IInsurancePolicyRepository instance</param>
    /// <param name="unitOfWork">IUnitOfWork instance</param>
    public RejectInsurancePolicyCommandHandler(
        IInsurancePolicyRepository insurancePolicyRepository,
        IUnitOfWork unitOfWork)
    {
        _insurancePolicyRepository = insurancePolicyRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(
        RejectInsurancePolicyCommand command, 
        CancellationToken cancellationToken)
    {
        var insurancePolicy = await _insurancePolicyRepository.GetByIdAsync(command.InsurancePolicyId, cancellationToken);

        if(insurancePolicy == null) 
        {
            return Result.Failure(InsurancePoliciesErrors.NotFound);
        }

        var result = insurancePolicy.Reject();

        if(result.IsFailure)
        {
            return result;
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
{
}

