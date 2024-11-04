using Microsoft.AspNetCore.Mvc;
using LR.Models;

namespace LR.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.Title = "Home";
            return View();
        }

        [HttpGet("ContactHTML")]
        public IActionResult ContactHTML()
        {
            ViewBag.Title = "Contact - HTML";
            return View();
        }

        [HttpGet("ContactTagHelper")]
        public IActionResult ContactTagHelper()
        {
            ViewBag.Title = "Contact - Tag Helper";
            return View();
        }

        [HttpPost("Contact")]
        public IActionResult Contact(ContactModel model)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("ContactHTML");

            ViewBag.Title = "Contact Results";
            return View("ContactResults", model);
        }
    }
}
