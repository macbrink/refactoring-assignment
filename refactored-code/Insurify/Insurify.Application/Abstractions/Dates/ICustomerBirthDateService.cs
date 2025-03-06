using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurify.Application.Abstractions.Dates
{
    /// <summary>
    /// Service to get the minimum and maximum birth dates for any customer.
    /// </summary>
    public interface ICustomerBirthDateService
    {
        /// <summary>
        /// Get the maximum birth date for any customer.
        /// </summary>
        /// <returns>Maximum birthdate, the youngest customer allowed</returns>
        DateOnly GetMaximumBirthDate();

        /// <summary>
        /// Get the minimum birth date for any customer.
        /// </summary>
        /// <returns>Minumum birthdate, the oldest customer allowed</returns>
        DateOnly GetMinimumBirthDate();
    }
}
