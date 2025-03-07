using System;

namespace Insurify.Domain.Customers;

/// <summary>
/// Represents the status of a customer.
/// </summary>
public enum CustomerStatus
{
    /// <summary>
    /// The customer has been created.
    /// </summary>
    Created = 1,

    /// <summary>
    /// The customer is active.
    /// </summary>
    Active = 2,

    /// <summary>
    /// The customer has been rejected.
    /// </summary>
    Rejected = 3,

    /// <summary>
    /// The customer has been archived.
    /// </summary>
    Archived = 4
}
