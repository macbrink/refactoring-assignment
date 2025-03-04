using Insurify.Application.Abstractions.Messaging;
using Insurify.Application.Insurances.Shared;

namespace Insurify.Application.Insurances.Search;

/// <summary>
/// Represents a query to get all insurances.
/// </summary>
public sealed record SearchInsurancesQuery(string SearchFor) : IQuery<List<InsuranceResponse>>;
