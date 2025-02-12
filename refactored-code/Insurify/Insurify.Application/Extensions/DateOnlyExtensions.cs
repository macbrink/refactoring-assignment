namespace Insurify.Application.Extensions;

/// <summary>
/// Extensions for <see cref="DateTime"/>.
/// </summary>
public static class DateOnlyExtensions
{
    /// <summary>
    /// Calculate the age of a person based on the date of birth.
    /// </summary>
    /// <param name="dateOfBirth">Date of birth</param>
    /// <returns>The Age</returns>
    public static int CalculateAge(this DateOnly dateOfBirth)
    {
        var today = DateOnly.FromDateTime(DateTime.Today);
        var age = today.Year - dateOfBirth.Year;
        if(dateOfBirth > today.AddYears(-age))
        {
            age--;
        }

        if (age < 0)
        {
            throw new ArgumentException("Invalid date of birth");
        }

        return age;
    }
}

