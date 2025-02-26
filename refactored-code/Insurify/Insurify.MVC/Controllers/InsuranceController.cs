using Insurify.Application.Insurances.GetInsurances;
using Insurify.Domain.Abstractions;
using Insurify.Domain.Insurances;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Insurify.MVC.Controllers;
public class InsuranceController : Controller
{
    private readonly ISender _sender;

    public InsuranceController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var query = new GetInsurancesQuery();

        CancellationToken cancellationToken = new();

        var result = await _sender.Send(query, cancellationToken);

        return View(result.Value);
    }
}
