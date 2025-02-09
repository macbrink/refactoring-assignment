using System;

namespace Insurify.Domain.InsurancePolicies;

/// <summary>
/// Represents the status of a cover.
/// </summary>
public enum InsurancePolicyStatus
{
    /// <summary>
    /// The cover has been applied for.
    /// </summary>
    AppliedFor = 1,

    /// <summary>
    /// The policy has been confirmed.
    /// </summary>
    Confirmed = 2,

    /// <summary>
    /// The policy has been rejected.
    /// </summary>
    Rejected = 3,

    /// <summary>
    /// The policy has been cancelled.
    /// </summary>
    Cancelled = 4,

    /// <summary>
    /// The policy has been completed.
    /// </summary>
    Completed = 5
}
