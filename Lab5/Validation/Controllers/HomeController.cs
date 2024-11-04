using Microsoft.AspNetCore.Mvc;

namespace Validation;


[Route("")]
[Route("Home")]
public class HomeController : Controller
{
    public HomeController()
    {

    }
    [Route("")]
    [Route("Index")]
    public IActionResult Index()
    {
        return View();
    }
    [Route("Index2")]
    public IActionResult Index2()
    {
        throw new Exception("Oh No!  The site is broken!");
    }
    [Route("Index3")]
    public IActionResult Index3()
    {
        return StatusCode(401);
    }
}
