using Insurify.Application.Customers.Add;
using Insurify.Application.Exceptions;
using Insurify.Application.InsurancePolicies.ApplyFor;
using Insurify.Application.InsurancePolicies.GetById;
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
            InsuranceId = result.Value.Id,
            BirthDate = DateOnly.FromDateTime(DateTime.Now.AddYears(-16))
        };
        ViewBag.Title = $"Apply for {result.Value.Name}";
        return View(viewModel);
    }

    // POST: InsurancePolicies/ApplyFor
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ApplyFor(ApplyForInsurancePolicyViewModel viewModel)
    {
        if(!ModelState.IsValid)
        {
            return View(viewModel);
        }

        int customerId;
        int insurancePolicyId;

        try
        {
            var customerResult = await AddCustomer(viewModel);


            if (customerResult.IsFailure)
            {
                ModelState.AddModelError(string.Empty, customerResult.Error.Name);
                return View(viewModel);
            }
            customerId = customerResult.Value;
        }
        catch(ValidationException ex)
        {
            foreach (var error in ex.Errors)
            {
                ModelState.AddModelError(string.Empty, error.ErrorMessage);
            }
            return View(viewModel);
        }

        try
        {
            var insurancePolicyResult = await ApplyForInsurancePolicy(viewModel, customerId);

            if (insurancePolicyResult.IsFailure)
            {
                ModelState.AddModelError(string.Empty, insurancePolicyResult.Error.Name);
                return View(viewModel);
            }

            insurancePolicyId = insurancePolicyResult.Value;
        }
        catch (ValidationException ex)
        {
            foreach (var error in ex.Errors)
            {
                ModelState.AddModelError(string.Empty, error.ErrorMessage);
            }
            return View(viewModel);
        }

        return RedirectToAction(nameof(Details), new { id = insurancePolicyId} );
    }

    // GET: InsurancePolicies/Details/5
    [HttpGet]
    public async Task<IActionResult> Details(int? id)
    {
        if(id == null)
        {
            return NotFound();
        }
        Result<InsurancePolicyResponse> result = await _sender.Send(new GetInsurancePolicyByIdQuery(id), new CancellationToken());
        if(result.IsFailure)
        {
            return NotFound();
        }
        return View(result.Value);
    }

    private async Task<Result<int>> ApplyForInsurancePolicy(ApplyForInsurancePolicyViewModel viewModel, Result<int> customerId)
    {
        var applyForInsurancePolicyCommand = new ApplyForInsurancePolicyCommand(
            viewModel.InsuranceId,
            customerId.Value,
            DateTime.Now.AddDays(7),
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
