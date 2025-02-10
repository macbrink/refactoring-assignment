namespace Insurify.Domain.Shared;

/// <summary>
/// Represents a Money.
/// </summary>
/// <param name="Amount">The amount</param>
/// <param name="Currency">The currency</param>
public sealed record Money(decimal Amount, Currency Currency)
{
    /// <summary>
    /// Adds two money objects.
    /// <example>
    /// var firstAmaount = new Money(10, Currency.Usd);
    /// var secondAmount = new Money(20, Currency.Usd);
    /// var sumAmount = firstAmount + secondAmount; // sumAmount.Amount == 30
    /// </example>
    /// </summary>
    /// <param name="first">The first Money object in the equation</param>
    /// <param name="second">The escond Money object in the equeation</param>
    /// <returns>A Money object representing the sum of the amounts</returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static Money operator +(Money first, Money second)
    {
        if(first.Currency != second.Currency)
        {
            throw new InvalidOperationException("Currencies have to be equal");
        }

        return new Money(first.Amount + second.Amount, first.Currency);
    }
    
    /// <summary>
    /// Represents Money with no amount or currency
    /// </summary>
    /// <returns></returns>
    public static Money Zero() => new(0, Currency.None);

    /// <summary>
    /// Represents Money with no amount with a currency
    /// </summary>
    /// <param name="currency"></param>
    /// <returns></returns>
    public static Money Zero(Currency currency) => new(0, currency);

    /// <summary>
    /// Checks if the Money is zero
    /// </summary>
    /// <returns></returns>
    public bool IsZero() => this == Zero(Currency);
}
