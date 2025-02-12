using FluentValidation;

namespace Insurify.Application.InsurancePolicies.ApplyForInsurancePolicy;

/// <summary>
/// Validator for the <see cref="ApplyForInsurancePolicyCommand"/>.
/// </summary>
public class ApplyForInsurancePolicyCommandValidator : AbstractValidator<ApplyForInsurancePolicyCommand>

/// <summary>
/// Constructor for the <see cref="ApplyForInsurancePolicyCommandValidator"/>.
/// </summary>
{
    public ApplyForInsurancePolicyCommandValidator()
    {
        RuleFor(command => command.InsuranceId).NotEmpty();
        RuleFor(command => command.SubscriberId).NotEmpty();
        RuleFor(command => command.StartDate).GreaterThanOrEqualTo(DateTime.Now);
        RuleFor(command => command.InsuredAmount).NotEmpty();
    }
}

