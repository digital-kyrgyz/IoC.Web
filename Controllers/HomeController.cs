using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Ioc.Web.Models;
namespace Ioc.Web.Controllers;

public class HomeController : Controller
{
    //private readonly ISingletonDateService _singleton;
    //private readonly IScopedDateService _scoped;
    private readonly ITransientDateService _transient;
    public HomeController(ITransientDateService transient)
    {
        _transient = transient;
    }

    public IActionResult Index([FromServices] ITransientDateService transient)
    {
        ViewBag.Time1 = _transient.GetDateTime.TimeOfDay.ToString();
        ViewBag.Time2 = transient.GetDateTime.TimeOfDay.ToString();
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
