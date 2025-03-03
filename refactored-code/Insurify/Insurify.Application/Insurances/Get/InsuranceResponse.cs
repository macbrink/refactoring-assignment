using Insurify.Domain.Abstractions;

namespace Insurify.Application.Insurances.Get;

public sealed class InsuranceResponse
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal PriceAmount { get; set; }

    public string PriceCurrency { get; set; }
}