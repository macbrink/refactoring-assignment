using Insurify.Application.Insurances.GetById;
using Insurify.Application.Insurances.Shared;
using Insurify.Domain.Abstractions;
using Insurify.MVC.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Insurify.MVC.Controllers;

public class InsurancePoliciesController : Controller
{
    private readonly ISender _sender;

    public InsurancePoliciesController(ISender sender)
    {
        _sender = sender;
    }

    // GET: InsurancePolicies/ApplyFor/5
    [HttpGet]
    public async Task<IActionResult> ApplyFor(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Result<InsuranceResponse> result = await _sender.Send(new GetInsuranceByIdQuery(id), new CancellationToken());

        if (result.IsFailure)
        {
            return NotFound();
        }

        var viewModel = new ApplyForInsurancePolicyViewModel()
        {
            InsuranceId = result.Value.Id
        };
        ViewBag.Title = $"Apply for {result.Value.Name}";
        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ApplyFor(ApplyForInsurancePolicyViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(viewModel);
        }

        return RedirectToAction("Index", "Home");
    }
}
