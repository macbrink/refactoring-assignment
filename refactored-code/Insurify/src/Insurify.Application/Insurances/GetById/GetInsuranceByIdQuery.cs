using Insurify.Application.Abstractions.Messaging;
using Insurify.Application.Insurances.Shared;

namespace Insurify.Application.Insurances.GetById;

/// <summary>
/// Represents a query to get an insurance by id.
/// </summary>
/// <param name="Id">an Id to get Insurances</param>
public record GetInsuranceByIdQuery(int? Id) : IQuery<InsuranceResponse>;
