namespace Insurify.Domain.InsurancePolicies;

/// <summary>
/// Represents a repository for insurance policies.
/// </summary>
public interface IInsurancePolicyRepository
{
    /// <summary>
    /// Gets all insurance policies by Insurance Id.
    /// </summary>0
    /// <param name="insuranceId">The id of an insurance.</param>
    /// <param name="cancellationToken">a CancellationToken</param>
    /// <returns></returns>
    Task<ICollection<InsurancePolicy>> GetPoliciesByInsuranceId(int insuranceId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Adds an insurance policy to the repository.
    /// </summary>
    /// <param name="id">The Id vor the insurance policy</param>
    /// <param name="cancellationToken">a cancellation token</param>
    /// <returns></returns>
    Task<InsurancePolicy?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Adds an insurance policy to the repository.
    /// </summary>
    /// <param name="insurancePolicy">The insurance policy</param>
    /// <param name="cancellationToken">a cancellation token</param>
    /// <returns></returns>
    Task Add(InsurancePolicy insurancePolicy, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an insurance policy in the repository.
    /// </summary>
    /// <param name="insurancePolicy">The insurance policy</param>
    /// <param name="cancellationToken">a cancellation token</param>
    Task Update(InsurancePolicy insurancePolicy, CancellationToken cancellationToken = default);


}
