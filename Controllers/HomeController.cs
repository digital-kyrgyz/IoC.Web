using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Ioc.Web.Models;
namespace Ioc.Web.Controllers;

public class HomeController : Controller
{
    //private readonly ISingletonDateService _singleton;
    private readonly IScopedDateService _scoped;

    public HomeController(IScopedDateService scoped)
    {
        _scoped = scoped;
    }

    public IActionResult Index([FromServices] IScopedDateService scoped)
    {
        ViewBag.Time1 = _scoped.GetDateTime.TimeOfDay.ToString();
        ViewBag.Time2 = scoped.GetDateTime.TimeOfDay.ToString();
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
