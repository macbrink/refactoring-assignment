namespace Insurify.Domain.InsurancePolicies;

/// <summary>
/// Represents a repository for insurance policies.
/// </summary>
public interface IInsurancePolicyRepository
{
    /// <summary>
    /// Gets an insurance policy by its id.
    /// </summary>
    /// <param name="id">The insurance poicy id.</param>
    /// <param name="cancellationToken">a CancellationToken.</param>
    /// <returns>InsurancePolicy object</returns>
    Task<InsurancePolicy> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets all insurance policies by Insurance Id.
    /// </summary>0
    /// <param name="insuranceId">The id of an insurance.</param>
    /// <param name="cancellationToken">a CancellationToken</param>
    /// <returns></returns>
    Task<ICollection<InsurancePolicy>> GetPoliciesByInsuranceId(int insuranceId, CancellationToken cancellationToken = default);
}
