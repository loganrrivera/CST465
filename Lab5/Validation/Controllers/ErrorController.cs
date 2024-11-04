using Microsoft.AspNetCore.Mvc;

namespace Validation.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error")]
        public IActionResult Index()
        {
            int statusCode = HttpContext.Response.StatusCode;
            if (statusCode == 404)
                return View("NotFound");
            if (statusCode == 500)
                return View("ServerError");
            return View();
        }
    }
}
