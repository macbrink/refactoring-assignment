using Insurify.Domain.InsurancePolicies;

namespace Insurify.Application.InsurancePolicies.GetInsurancePolicy;

/// <summary>
/// Response for the <see cref="GetInsurancePolicyQuery"/>.
/// </summary>
public class InsurancePolicyResponse
{
    /// <summary>
    /// Gets or initializes the insurance policy id.
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    /// Gets or initializes the insurance id.
    /// </summary>
    public int InsuranceId { get; init; }

    /// <summary>
    /// Gets or initializes the subscriber id.
    /// </summary>
    public int SubscriberId { get; init; }

    /// <summary>
    /// Gets or initializes the start date.
    /// </summary>
    public DateTime StartDate { get; init; }

    /// <summary>
    /// Gets or initializes the insured amount.
    /// </summary>
    public decimal InsuredAmount { get; init; }

    /// <summary>
    /// Gets or initializes the insured currency.
    /// </summary>
    public string InsuredCurrency { get; init; } = string.Empty;

    /// <summary>
    /// Gets or initializes the fee amount.
    /// </summary>
    public decimal FeeAmount { get; init; }

    /// <summary>
    /// Gets or initializes the fee currency.
    /// </summary>
    public string FeeCurrency { get; init; } = string.Empty;

    /// <summary>
    /// Gets or initializes the status.
    /// </summary>
    public InsurancePolicyStatus Status { get; init; }
}

