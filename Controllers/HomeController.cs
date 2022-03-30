using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Ioc.Web.Models;
namespace Ioc.Web.Controllers;

public class HomeController : Controller
{
    private readonly ISingletonDateService _singleton;
    public HomeController(ISingletonDateService singleton)
    {
        _singleton = singleton;
    }

    public IActionResult Index([FromServices] ISingletonDateService singleton2)
    {
        ViewBag.Time1 = _singleton.GetDateTime.TimeOfDay.ToString();
        ViewBag.Time2 = singleton2.GetDateTime.TimeOfDay.ToString();
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
