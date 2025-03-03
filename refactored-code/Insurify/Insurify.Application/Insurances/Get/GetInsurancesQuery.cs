using Insurify.Application.Abstractions.Messaging;

namespace Insurify.Application.Insurances.Get;

/// <summary>
/// Represents a query to get all insurances.
/// </summary>
public sealed record GetInsurancesQuery(string SearchFor) : IQuery<List<InsuranceResponse>>;
