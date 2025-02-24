using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insurify.Application.Abstractions.Messaging;
using Insurify.Domain.Insurances;

namespace Insurify.Application.Insurances.GetInsurances;

/// <summary>
/// Represents a query to get all insurances.
/// </summary>
public sealed record GetInsurancesQuery : IQuery<IReadOnlyCollection<Insurance>>;
