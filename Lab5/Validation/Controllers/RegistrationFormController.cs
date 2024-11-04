using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Validation;

[Route("Registration")]
public class RegistrationFormController : Controller
{
    [Route("")]
    [HttpGet]
    public IActionResult Index()
    {
        RegistrationFormModel model = new RegistrationFormModel();
        //Convert the states to List<SelectListItem> because that is what a select/dropdown list will want
        model.StateList = new SelectList(GetStates(), "Abbreviation", "Name").ToList();
        return View(model);
    }
    [HttpPost]
    [Route("")]
    public IActionResult Index(RegistrationFormModel model)
    {
        //Check if everything validates against the model constraints
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        return View("Success");
    }
    ///Returns a hard-coded list of states, but these could come from a database also
    private List<USState> GetStates()
    {
        return new List<USState>(){
                new USState(){Abbreviation = "OR", Name = "Oregon"},
                new USState(){Abbreviation = "CA", Name = "California"},
                new USState(){Abbreviation = "WA", Name = "Washington"},
                new USState(){Abbreviation = "TX", Name = "Texas"},
                new USState(){Abbreviation = "TN", Name = "Tennessee"}
            };

    }
}
