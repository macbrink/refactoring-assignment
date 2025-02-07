using System.Diagnostics.CodeAnalysis;

namespace Insurify.Domain.Abstractions;

/// <summary>
/// Represents a result.
/// </summary>
public class Result
{
    /// <summary>
    /// Represents a result with no value.
    /// </summary>
    /// <param name="isSuccess">Wether the result is successful</param>
    /// <param name="error">The error if the result is not successful</param>
    /// <exception cref="InvalidOperationException">An exception is thrown when a result is not succesful, but no error is given</exception>
    public Result(bool isSuccess, Error error)
    {
        if(isSuccess && error != Error.None)
        {
            throw new InvalidOperationException();
        }

        if(!isSuccess && error == Error.None)
        {
            throw new InvalidOperationException();
        }

        IsSuccess = isSuccess;
        Error = error;
    }

    /// <summary>
    /// Wether the result is successful.
    /// </summary>
    public bool IsSuccess { get; }

    /// <summary>
    /// Wether the result is not successful.
    /// </summary>
    public bool IsFailure => !IsSuccess;

    /// <summary>
    /// The error if the result is not successful.
    /// </summary>
    public Error Error { get; }

    /// <summary>
    /// Represents a successful result.
    /// </summary>
    /// <returns>Succesfull result with no error</returns>
    public static Result Success() => new(true, Error.None);

    /// <summary>
    /// Represents a result with an error.
    /// </summary>
    /// <param name="error">The error</param>
    /// <returns>a Result object</returns>
    public static Result Failure(Error error) => new(false, error);

    /// <summary>
    /// Represents a result with a value.
    /// </summary>
    /// <typeparam name="TValue">Generic type, to be specified later</typeparam>
    /// <param name="value">The value of the generic type</param>
    /// <returns>a Result object</returns>
    public static Result<TValue> Success<TValue>(TValue value) => new(value, true, Error.None);

    /// <summary>
    /// Represents a result with an error.
    /// </summary>
    /// <typeparam name="TValue">Generic type, to be specified later</typeparam>
    /// <param name="error">The error</param>
    /// <returns>a Result object</returns>
    public static Result<TValue> Failure<TValue>(Error error) => new(default, false, error);

    /// <summary>
    /// Represents a result with a value.
    /// </summary>
    /// <typeparam name="TValue">a generic type, to be specified later</typeparam>
    /// <param name="value">a value</param>
    /// <returns>a Result object</returns>
    public static Result<TValue> Create<TValue>(TValue? value) =>
        value is not null ? Success(value) : Failure<TValue>(Error.NullValue);
}

/// <summary>
/// Represents a result with a value.
/// </summary>
/// <typeparam name="TValue">Generic type, to be specified later</typeparam>
public sealed class Result<TValue> : Result
{
    private readonly TValue? _value;

    /// <summary>
    /// Initializes a new instance of the <see cref="Result{TValue}"/> class.
    /// </summary>
    /// <param name="value">a value</param>
    /// <param name="isSuccess">wether the rssult is successful</param>
    /// <param name="error"></param>
    public Result(TValue? value, bool isSuccess, Error error)
        : base(isSuccess, error)
    {
        _value = value;
    }

    /// <summary>
    /// The value of the result.
    /// </summary>
    [NotNull]
    public TValue Value => IsSuccess
        ? _value!
        : throw new InvalidOperationException("The value of a failure result can not be accessed.");

    /// <summary>
    /// Represents a successful result.
    /// </summary>
    /// <param name="value">a value</param>
    public static implicit operator Result<TValue>(TValue? value) => Create(value);
}