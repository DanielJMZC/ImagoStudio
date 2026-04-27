using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

public class AccountController: Controller
{
    public IActionResult Login()
    {
        return View();
    }

    public IActionResult Register()
    {
        return View();
    }

    public IActionResult RegisterProfile()
    {
        var id_user = HttpContext.Session.GetInt32("user_id");

        if (id_user == null)
        {
            return RedirectToAction("Login");
        }

        return View();
    }

    private readonly IUsersService _service;
    public AccountController(IUsersService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Register(Users user)
    {
        user = await _service.AddUser(user);

        if (user.correo == "invalid")
        {
            ModelState.AddModelError("correo", "El correo electrónico debe ser único");
            return View(user);
        }

        if (user.user_id != null) {
            Console.WriteLine(user.user_id.ToString());
            if (user.user_id != null) {
                HttpContext.Session.SetInt32("user_id", user.user_id.Value);
            }

            return RedirectToAction("RegisterProfile");
        }

            return View();
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
            return RedirectToAction("Index", "Home");
        }

        return View(model);
        
    }
    

    [HttpPost]
    public async Task<IActionResult> Login(Users user)
    {
        user = await _service.LoginUser(user);

        if (user.correo == "invalid")
        {
            ModelState.AddModelError("correo", "Credenciales inválidas");
            ModelState.AddModelError("encrypted_password", "Credenciales inválidas");
            return View(user);
        }

        if (user.user_id != null ) {
            Console.WriteLine(user.user_id.ToString());
            
            if (user.user_id != null) {
                HttpContext.Session.SetInt32("user_id", user.user_id.Value);
            }
            
            if (user.country_id != null) {
                return RedirectToAction("Index", "Home");
            } else
            {
                return RedirectToAction("RegisterProfile");
            }
        }

        return View();
    }

   
}