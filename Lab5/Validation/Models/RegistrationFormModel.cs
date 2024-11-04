using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Validation;

public class RegistrationFormModel
{

    [Required(ErrorMessage = "First name must be entered, man")]
    [DisplayName("First Name")]
    [StringLength(20)]
    public string FirstName { get; set; } = "";

    [Required]
    [DisplayName("Last Name")]
    [StringLength(40)]
    public string LastName { get; set; } = "";

    [Required]
    [DisplayName("Email Address")]
    public string EmailAddress { get; set; } = "";

    [Required]
    [DisplayName("Phone Number")]
    [RegularExpression(@"\d{3}\-\d{3}\-\d{4}", ErrorMessage = "Phone number must be in the format 555-555-0123")]
    public string PhoneNumber { get; set; } = "";

    [DisplayName("Address")]
    public string Address { get; set; } = "";
    [DisplayName("City")]
    public string City { get; set; } = "";
    [DisplayName("State")]
    public string State { get; set; } = "";
    [DisplayName("Zip Code")]
    public string ZipCode { get; set; } = "";

    public List<SelectListItem> StateList { get; set; } = new List<SelectListItem>();
}
