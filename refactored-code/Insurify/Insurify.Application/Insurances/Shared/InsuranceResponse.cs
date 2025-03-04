
namespace Insurify.Application.Insurances.Shared;

/// <summary>
/// Represents an insurance response.
/// </summary>
public sealed class InsuranceResponse
{
    /// <summary>
    /// Gets or sets the id.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name.of the Insurance
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the description of the Insurance
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the price amount of the Insurance
    /// </summary>
    public decimal PriceAmount { get; set; }

    /// <summary>
    /// Gets or sets the price currency of the Insurance
    /// </summary>
    public string PriceCurrency { get; set; } = string.Empty;
}