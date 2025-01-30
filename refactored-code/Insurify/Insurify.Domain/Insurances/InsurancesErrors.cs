using Insurify.Domain.Abstractions;

namespace Insurify.Domain.Insurances;

public static class InsurancesErrors
{
    public static readonly Error NotFound = new(
        "Insurances.NotFound", 
        "Insurance not found");
}

