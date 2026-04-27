using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AWAQTrainingGrounds.Models;
using System.Linq; 

namespace AWAQTrainingGrounds.Controllers;

public class HomeController : Controller
{
    private readonly IUsersService _service;
    public HomeController(IUsersService service)
    {
        _service = service;
    }

    public IActionResult Index()
    {
        Users user = new Users();
        user.user_id = HttpContext.Session.GetInt32("user_id");
        return View(user);
    }

   public async Task<IActionResult> Profile()
    {
        var id_user = HttpContext.Session.GetInt32("user_id");

        if (!id_user.HasValue || id_user.Value <= 0)
        {
            return RedirectToAction("Index");
        }

        ProfileViewModel model = await _service.GetProfile(id_user.Value);

        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}