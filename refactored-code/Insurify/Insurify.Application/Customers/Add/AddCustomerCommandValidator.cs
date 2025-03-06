using FluentValidation;
using Insurify.Application.Abstractions.Dates;

namespace Insurify.Application.Customers.Add;

/// <summary>
/// Validator for the AddCustomerCommand.
/// </summary>
public class AddCustomerCommandValidator : AbstractValidator<AddCustomerCommand>
{
    /// <summary>
    /// Constructor for the AddCustomerCommandValidator.
    /// </summary>
    /// <param name="birthDateService">Service to get maximum and minimum birthdates for a customer</param>
    public AddCustomerCommandValidator(ICustomerBirthDateService birthDateService)
    {
        RuleFor(command => command.FirstName).NotEmpty();
        RuleFor(command => command.LastName).NotEmpty();
        RuleFor(command => command.Email).EmailAddress();
        RuleFor(command => command.BirthDate).LessThanOrEqualTo(birthDateService.GetMaximumBirthDate());
        RuleFor(command => command.BirthDate).GreaterThanOrEqualTo(birthDateService.GetMinimumBirthDate());
        RuleFor(command => command.AddressCountry).NotEmpty();
        RuleFor(command => command.AddressPostalCode).NotEmpty();
        RuleFor(command => command.AddressState).NotEmpty();
        RuleFor(command => command.AddressCity).NotEmpty();
        RuleFor(command => command.AddressStreet).NotEmpty();
    }
}
