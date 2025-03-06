using System.ComponentModel.DataAnnotations;
using Insurify.Application.Abstractions.Dates;

namespace Insurify.MVC.Models;

public class ApplyForInsurancePolicyViewModel
{
    // Customer Entries
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    [DataType(DataType.Date)]
    public DateOnly BirthDate { get; set; }
    

    [Display(Name = "Country")]
    public string AddressCountry { get; set; } = string.Empty;

    [Display(Name = "State")]
    public string AddressState { get; set; } = string.Empty;

    [Display(Name = "Postal Code")]
    public string AddressPostalCode { get; set; } = string.Empty;

    [Display(Name = "City")]
    public string AddressCity { get; set; } = string.Empty;

    [Display(Name = "Street")]
    public string AddressStreet { get; set; } = string.Empty;

    // InsurancePolicy entries
    public int InsuranceId { get; set; }

    [Display(Name = "Insured Amount")]
    public decimal InsuredAmount { get; set; }

    [Display(Name = "Security Certificate")]
    public bool HasSecurityCertificate { get; set; }
}
