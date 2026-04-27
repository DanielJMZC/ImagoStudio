using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AWAQTrainingGrounds.Models;
using System.Linq; 

namespace AWAQTrainingGrounds.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        Users user = new Users();
        user.user_id = HttpContext.Session.GetInt32("user_id");
        return View(user);
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