namespace Insurify.Domain.Shared;

/// <summary>
/// Represents a currency.
/// </summary>
public sealed record Currency
{
    /// <summary>
    /// The currency code for 'No Currency'.
    /// </summary>
    internal static readonly Currency None = new("");

    /// <summary>
    /// The currency code for US dollar.
    /// </summary>
    public static readonly Currency Usd = new("USD");

    /// <summary>
    /// The currency code for Euro.
    /// </summary>
    public static readonly Currency Eur = new("EUR");

    /// <summary>
    /// Creates a new instance of the <see cref="Currency"/> class.
    /// </summary>
    /// <param name="code"></param>
    private Currency(string code) => Code = code;

    /// <summary>
    /// Gets the currency code.
    /// </summary>
    public string Code { get; init; }

    /// <summary>
    /// Gets the currency by symbol.
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    /// <exception cref="ApplicationException"></exception>
    public static Currency FromCode(string code)
    {
        return All.FirstOrDefault(c => c.Code == code) ??
               throw new ApplicationException("The currency code is invalid");
    }

    /// <summary>
    /// Gets all the available currencies.
    /// </summary>
    public static readonly IReadOnlyCollection<Currency> All = new[]
    {
        Usd,
        Eur
    };
}
