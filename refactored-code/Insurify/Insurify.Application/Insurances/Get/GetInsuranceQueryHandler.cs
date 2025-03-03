using Insurify.Application.Abstractions.Data;
using Insurify.Application.Abstractions.Messaging;
using Insurify.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Insurify.Application.Insurances.Get
{
    /// <summary>
    /// Handles queries for getting insurance information.
    /// </summary>
    public sealed class GetInsuranceQueryHandler 
        : IQueryHandler<GetInsurancesQuery, List<InsuranceResponse>>
    {
        private readonly IApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetInsuranceQueryHandler"/> class.
        /// </summary>
        /// <param name="context">The application database context.</param>
        public GetInsuranceQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Handles the query for getting insurances that match the search string from the request.
        /// </summary>
        /// <param name="request"><see cref="GetInsurancesQuery"/></param>
        /// <param name="cancellationToken">a CancelationToken</param>
        /// <returns>List of all insurances, matcing the search string</returns>
        public async Task<Result<List<InsuranceResponse>>> Handle(GetInsurancesQuery request, CancellationToken cancellationToken)
        {
            var insurances = await _context.Insurances
                .Select(insurance => new InsuranceResponse
                {
                    Id = insurance.Id,
                    Name = insurance.Name.Value,
                    Description = insurance.Description.Value,
                    PriceAmount = insurance.Price.Amount,
                    PriceCurrency = insurance.Price.Currency.Code
                })
                .ToListAsync(cancellationToken);

            return insurances;
        }
    }
}
