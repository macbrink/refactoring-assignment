using Insurify.Application.Abstractions.Messaging;
using Insurify.Application.InsurancePolicies.GetById;

namespace Insurify.Application.InsurancePolicies.Get
{
    /// <summary>
    /// Represents a query to get all insurance policies.
    /// </summary>
	public record GetInsurancePolicyListQuery() : IQuery<List<InsurancePolicyResponse>>;
}
