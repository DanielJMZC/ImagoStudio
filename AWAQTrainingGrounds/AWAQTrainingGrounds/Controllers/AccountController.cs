using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

public class AccountController: Controller
{


    private readonly IUsersService _service;
    public AccountController(IUsersService service)
    {
        _service = service;
    }
    public IActionResult Login()
    {
        HttpContext.Session.Clear();
        return View();
    }

    public IActionResult Register()
    {
        HttpContext.Session.Clear(); 
        return View();
    }


    [HttpGet]
    public async Task<IActionResult> RegisterProfile()
    {
        var id_user = HttpContext.Session.GetInt32("user_id");

        if (id_user == null)
        {
            return RedirectToAction("Login");
        }

        RegisterViewModel model = new RegisterViewModel();
        model.countries = await _service.GetCountries();
        model.cosmetics = await _service.GetAvatars();

        return View(model);

    }

    [HttpPost]
    public async Task<IActionResult> Register(Users user)
    {
        var result = await _service.AddUser(user);

        if (result.message == "invalid")
        {
            ModelState.AddModelError("correo", "El correo electrónico debe ser único");
            return View(user);
        }

        if (result.user.user_id != null)
        {
            HttpContext.Session.SetInt32("user_id", result.user.user_id.Value);

            return RedirectToAction("RegisterProfile");
        }

        return View(user);
    }

    [HttpPost]
    public async Task<IActionResult> RegisterProfile(RegisterViewModel model)
    {     
        var id_user = HttpContext.Session.GetInt32("user_id");
        Console.WriteLine(id_user);
        
        if (id_user == null)
        {
            return RedirectToAction("Login");
        }

        DateTime birthdate = new DateTime(model.birth_year, model.birth_month, model.birth_day);


        model.user_id = id_user;
        model.fecha_de_nacimiento = birthdate;
        var fullTelefono = model.telefono_prefix + model.telefono;
        model.telefono = fullTelefono;
       
        await _service.UpdateUser(model);

        if (model.country_id != null)
        {
            return RedirectToAction("Profile", "Home");
        }

        return View(model);
        
    }
    

   [HttpPost]
    public async Task<IActionResult> Login(Users user)
    {
        var result = await _service.LoginUser(user);

        if (result.message == "invalid")
        {
            ModelState.AddModelError("correo", "Credenciales inválidas");
            ModelState.AddModelError("encrypted_password", "Credenciales inválidas");
            return View(user);
        }

        var loggedUser = result.user;

        if (loggedUser.user_id != null)
        {
            HttpContext.Session.SetInt32("user_id", loggedUser.user_id.Value);

            bool isAdmin = await _service.IsAdmin(loggedUser.user_id.Value);
            HttpContext.Session.SetInt32("is_admin", isAdmin ? 1 : 0);

            // 🔥 PRIORIDAD ADMIN
            if (isAdmin)
            {
                return RedirectToAction("Panel", "Admin");
            }

            if (loggedUser.country_id != null)
            {
                return RedirectToAction("Profile", "Home");
            }
            else
            {
                return RedirectToAction("RegisterProfile");
            }
        }

        return View(user);
    }

   
}