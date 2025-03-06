using Insurify.Application.Customers.Add;
using Insurify.Application.InsurancePolicies.ApplyFor;
using Insurify.Application.Insurances.GetById;
using Insurify.Application.Insurances.Shared;
using Insurify.Domain.Abstractions;
using Insurify.Domain.Shared;
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
        if(!ModelState.IsValid)
        {
            return View(viewModel);
        }

        Result<int> customerId = await AddCustomer(viewModel);

        if(customerId.IsFailure)
        {
            ModelState.AddModelError(string.Empty, customerId.Error.Name);
            return View(viewModel);
        }
        
        var insurancePolicyId = await ApplyForInsurancePolicy(viewModel, customerId);

        if(insurancePolicyId.IsFailure)
        {
            ModelState.AddModelError(string.Empty, insurancePolicyId.Error.Name);
            return View(viewModel);
        }

        return RedirectToAction("Index", "Home");
    }

    private async Task<Result<int>> ApplyForInsurancePolicy(ApplyForInsurancePolicyViewModel viewModel, Result<int> customerId)
    {
        var applyForInsurancePolicyCommand = new ApplyForInsurancePolicyCommand(
            viewModel.InsuranceId,
            customerId.Value,
            DateTime.Now,
            new Money(
                viewModel.InsuredAmount,
                Currency.Eur)
        );

        return (Result<int>) await _sender.Send(applyForInsurancePolicyCommand, new CancellationToken());
    }

    private async Task<Result<int>> AddCustomer(ApplyForInsurancePolicyViewModel viewModel)
    {
        var command = new AddCustomerCommand(
            viewModel.FirstName,
            viewModel.LastName,
            viewModel.Email,
            viewModel.BirthDate,
            viewModel.AddressCountry,
            viewModel.AddressState,
            viewModel.AddressPostalCode,
            viewModel.AddressCity,
            viewModel.AddressStreet,
            viewModel.HasSecurityCertificate
        );

        Result<int> customerId = (Result<int>)await _sender.Send(command, new CancellationToken());
        return customerId;
    }
}
