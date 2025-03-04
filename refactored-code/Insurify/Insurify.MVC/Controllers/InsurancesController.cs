using Insurify.Application.Insurances.Search;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Insurify.MVC.Controllers;
public class InsurancesController : Controller
{
    private readonly ISender _sender;

    public InsurancesController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var query = new SearchInsurancesQuery(string.Empty);

        CancellationToken cancellationToken = new();

        var result = await _sender.Send(query, cancellationToken);

        return View(result.Value);
    }
}