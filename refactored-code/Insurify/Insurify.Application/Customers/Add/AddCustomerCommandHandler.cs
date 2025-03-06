using Insurify.Application.Abstractions.Messaging;
using Insurify.Domain.Abstractions;
using Insurify.Domain.Customers;
using Insurify.Domain.Shared;

namespace Insurify.Application.Customers.Add
{
    internal sealed class AddCustomerCommandHandler : ICommandHandler<AddCustomerCommand, int>
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

        public async Task<Result<int>> Handle(
            AddCustomerCommand command, 
            CancellationToken cancellationToken)
        {
            if(await _customerRepository.EmailExists(command.Email))
            {
                return Result.Failure<int>(CustomerErrors.EmailExists);
            }

            var result = Customer.Create(
                _idCreator,
                new Name(command.FirstName),
                new Name(command.LastName),
                command.BirthDate,
                new Email(command.Email),
                new Address(
                    command.AddressCountry,
                    command.AddressState,
                    command.AddressPostalCode,
                    command.AddressCity,
                    command.AddressStreet),
                command.HasSecurityCertificate);

            _customerRepository.Add(result.Value, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            
            return result.Value.Id;
        }
    }
}
