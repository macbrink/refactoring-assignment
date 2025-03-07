using Insurify.Application.Abstractions.Messaging;

namespace Insurify.Application.Customers.GetById;

/// <summary>
/// Query to get the customer by Id
/// </summary>
/// <param name="Id">the Id</param>
public sealed record GetCustomerQuery(
	int Id) : IQuery<CustomerResponse>;
