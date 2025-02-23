using FluentValidation;
using Insurify.Application.Abstractions.Messaging;
using Insurify.Application.Exceptions;
using MediatR;

namespace Insurify.Application.Abstractions.Behaviors;

/// <summary>
/// Pipeline behavior to validate the request.
/// </summary>
/// <typeparam name="TRequest">Requst type</typeparam>
/// <typeparam name="TResponse">Reponse type</typeparam>
public class ValidationBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IBaseCommand
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    /// <summary>
    /// Constructor for the behavior.
    /// </summary>
    /// <param name="validators">The validators passed</param>
    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    /// <summary>
    /// Handles the request.
    /// </summary>
    /// <param name="request">The request</param>
    /// <param name="next">NThe next validator</param>
    /// <param name="cancellationToken">a Cancellationtaken</param>
    /// <returns>A Repsonse</returns>
    /// <exception cref="Exceptions.ValidationException"></exception>
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if(!_validators.Any())
        {
            return await next();
        }

        var context = new ValidationContext<TRequest>(request);

        var validationErrors = _validators
            .Select(validator => validator.Validate(context))
            .Where(validationResult => validationResult.Errors.Any())
            .SelectMany(validationResult => validationResult.Errors)
            .Select(validationFailure => new ValidationError(
                validationFailure.PropertyName,
                validationFailure.ErrorMessage))
            .ToList();

        if(validationErrors.Any())
        {
            throw new Exceptions.ValidationException(validationErrors);
        }

        return await next();
    }
}