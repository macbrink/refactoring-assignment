using Insurify.Domain.Abstractions;
using Insurify.Domain.Customers;
using Insurify.Domain.Shared;

namespace Insurify.Application.Customers.Add
{
    internal sealed class AddCustomerCommandHandler
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IIdCreator _idCreator;

        public AddCustomerCommandHandler(
            ICustomerRepository customerRepository,
            IUnitOfWork unitOfWork,
            IIdCreator idCreator)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
            _idCreator = idCreator;
        }

        public async Task<Result<int>> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {
            var result = Customer.Create(
                _idCreator,
                new Name(request.FirstName),
                new Name(request.LastName),
                request.BirthDate,
                new Email(request.Email),
                new Address(
                    request.AddressCountry,
                    request.AddressState,
                    request.AddressPostalCode,
                    request.AddressCity,
                    request.AddressStreet),
                request.HasSecurityCertificate);

            _customerRepository.Add(result.Value, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            
            return result.Value.Id;
        }
    }
}
