using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Validation.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error")]
        public IActionResult Index()
        {
            // Retrieve the status code from the request path if available
            var statusCodeReExecuteFeature = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            int statusCode = HttpContext.Response.StatusCode;

            // Handle specific status codes
            if (statusCode == 404)
                return View("NotFound");
            else if (statusCode == 500)
                return View("ServerError");

            // Fallback for other status codes
            ViewData["StatusCode"] = statusCode;
            return View("Index");
        }
    }
}
