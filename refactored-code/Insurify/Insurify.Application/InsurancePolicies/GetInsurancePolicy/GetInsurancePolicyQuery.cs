using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insurify.Application.Abstractions.Messaging;

namespace Insurify.Application.InsurancePolicies.GetInsurancePolicy;

/// <summary>
/// Query to get an insurance policy.
/// </summary>
/// <param name="InsurancePolicyId">The Id for the insurance policy</param>
public sealed record GetInsurancePolicyQuery(int InsurancePolicyId) : IQuery<InsurancePolicyResponse>;
