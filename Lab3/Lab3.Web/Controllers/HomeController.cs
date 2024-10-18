using Microsoft.AspNetCore.Mvc;
using Lab3.Objects;
using Lab3.Web.ExtensionMethods;
using System.Linq;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Laborers()
    {
        ChoreWorkforce myWorkforce = new ChoreWorkforce();

        myWorkforce.AddLaborer("Bob", 7, 5);
        myWorkforce.AddLaborer("Alice", 9, 7);
        myWorkforce.AddLaborer("Charlie", 10, 6);
        myWorkforce.AddLaborer("Daisy", 8, 4);

        for (int i = 0; i < 30; i++)
        {
            myWorkforce.AddRandomLaborer();
        }

        var filteredLaborers = myWorkforce.Laborers
            .Where(laborer => (laborer?.Age ?? -1) >= 3 && (laborer?.Age ?? -1) <= 10 && (laborer?.Difficulty ?? -1) <= 7)
            .OrderBy(laborer => laborer?.Name)
            .ToList();

        return View(filteredLaborers);
    }
}
