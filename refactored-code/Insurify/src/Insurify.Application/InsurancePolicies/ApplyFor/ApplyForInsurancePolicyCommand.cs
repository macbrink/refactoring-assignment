﻿using Insurify.Application.Abstractions.Messaging;
using Insurify.Domain.Shared;

namespace Insurify.Application.InsurancePolicies.ApplyFor;

/// <summary>
/// Record to apply for an insurance policy.
/// </summary>
/// <para>Use this command for existing customers</para>
/// <param name="InsuranceId">The id of the insurance the policy is for</param>
/// <param name="SubscriberId">The subcriber (custonmer) for this policy</param>
/// <param name="StartDate">Start date for this policy</param>
/// <param name="InsuredAmount">The insured amount on this policy</param>
public record ApplyForInsurancePolicyCommand(
    int InsuranceId,
    int SubscriberId,
    DateTime StartDate,
    Money InsuredAmount) : ICommand<int>;
 