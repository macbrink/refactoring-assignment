using Insurify.Application.Abstractions.Data;
using Insurify.Application.Abstractions.Messaging;
using Insurify.Application.Insurances.Shared;
using Insurify.Domain.Abstractions;
using Insurify.Domain.Insurances;
using Microsoft.EntityFrameworkCore;

namespace Insurify.Application.Insurances.GetById;

/// <summary>
/// Handles queries for getting insurance information.
/// </summary>
class GetInsuranceByIdQueryHandler : IQueryHandler<GetInsuranceByIdQuery, InsuranceResponse>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetInsuranceByIdQueryHandler"/> class.
    /// </summary>
    /// <param name="context">The application database context</param>
    public GetInsuranceByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Handles the query for getting insurance information by id.
    /// </summary>
    /// <param name="request"><see cref="GetInsuranceByIdQuery"/></param>
    /// <param name="cancellationToken">a CancellationToken</param>
    /// <returns></returns>
    public async Task<Result<InsuranceResponse>> Handle(GetInsuranceByIdQuery request, CancellationToken cancellationToken)
    {
        if(request.Id is null)
        {
            return Result.Failure<InsuranceResponse>(InsurancesErrors.NotFound);
        }

        var insurance = await _context.Insurances
            .Select(insurance => new InsuranceResponse
            {
                Id = insurance.Id,
                Name = insurance.Name.Value,
                Description = insurance.Description.Value,
                PriceAmount = insurance.Price.Amount,
                PriceCurrency = insurance.Price.Currency.Code
            })
            .FirstOrDefaultAsync(insurance => insurance.Id == request.Id, cancellationToken);

        if (insurance is null)
        {
            return Result.Failure<InsuranceResponse>(InsurancesErrors.NotFound);
        }

        return insurance;
    }
}
