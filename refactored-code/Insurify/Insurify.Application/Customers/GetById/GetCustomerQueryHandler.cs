using Insurify.Application.Abstractions.Messaging;
using Insurify.Domain.Abstractions;
using Insurify.Domain.Customers;

namespace Insurify.Application.Customers.GetById
{
    internal sealed class GetCustomerQueryHandler
        : IQueryHandler<GetCustomerQuery, CustomerResponse>
    {
        ICustomerRepository _customerRepository;

        /// <summary>
        /// Constructor for the GetCustomerQueryHandler
        /// </summary>
        /// <param name="customerRepository"><see cref="ICustomerRepository"/></param>
        public GetCustomerQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        /// <summary>
        /// Handle the query to get the customer by Id
        /// </summary>
        /// <param name="request"><see cref="GetCustomerQuery"/></param>
        /// <param name="cancellationToken">a CancellationToken</param>
        /// <returns><see cref="CustomerResponse"/></returns>
        /// <exception cref="Exception">Exception thrown wehen Customer is not found by Id</exception>
        public async Task<Result<CustomerResponse>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.Id, cancellationToken);
            return customer is null
                ? throw new Exception($"Customer with id {request.Id} was not found.")
                : new CustomerResponse
                {
                    Id = customer.Id,
                    FirstName = customer.FirstName.Value,
                    LastName = customer.LastName.Value,
                    Email = customer.Email.Value,
                    BirthDate = customer.BirthDate,
                    AddressCountry = customer.Address.Country,
                    AddressState = customer.Address.State,
                    AddressPostalCode = customer.Address.PostalCode,
                    AddressStreet = customer.Address.Street,
                    HasSecurityCertificate = customer.HasSecurityCertificate,
                    Status = customer.Status
                };
        }
    }
}
