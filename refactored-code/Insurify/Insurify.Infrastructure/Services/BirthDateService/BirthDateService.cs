using Insurify.Application.Abstractions.Dates;

namespace Insurify.Infrastructure.Services.BirthDateService;

/// <summary>
/// Service to get the minimum and maximum birth dates for any customer.
/// </summary>
public class BirthDateService : ICustomerBirthDateService
{
    private const int MinimumAge = 16;
    private const int MaximumAge = 100;

    private DateOnly _maximumBirthDate;
    private DateOnly _minimumBirthDate;

    /// <summary>
    /// Constructor for the BirthDateService.
    /// </summary>
    public BirthDateService() {
        _maximumBirthDate = DateOnly.FromDateTime(DateTime.Now.AddYears(-MinimumAge));
        _minimumBirthDate = DateOnly.FromDateTime(DateTime.Now.AddYears(-MaximumAge));
    }


    /// <summary>
    /// Get the maximum birth date for any customer.
    /// </summary>
    /// <returns>Maximum birthdate, the youngest customer allowed</returns>
    public DateOnly GetMaximumBirthDate()
    {
        return _maximumBirthDate;
    }

    /// <summary>
    /// Get the minimum birth date for any customer.
    /// </summary>
    /// <returns>Minumum birthdate, the oldest customer allowed</returns>
    public DateOnly GetMinimumBirthDate() {
        return _minimumBirthDate;
    }
}