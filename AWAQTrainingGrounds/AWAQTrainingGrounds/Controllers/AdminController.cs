using Microsoft.AspNetCore.Mvc;

public class AdminController : Controller
{
    public IActionResult Panel(string busqueda, int pagina = 1)
    {   
        
        List<UsuarioPanelViewModel> UsuariosPVM = new List<UsuarioPanelViewModel>();

        UsuariosPVM.Add(new UsuarioPanelViewModel
        {
            Nombre = "Ana López",
            Correo = "ana.lopez@test.com",
            Carrera = "ITC",
            País = "México",
            Monedas = 120,
            Progreso = 100
        });

        UsuariosPVM.Add(new UsuarioPanelViewModel
        {
            Nombre = "Carlos Ruiz",
            Correo = "carlos.ruiz@test.com",
            Carrera = "ISC",
            País = "México",
            Monedas = 250,
            Progreso = 25
        });

        UsuariosPVM.Add(new UsuarioPanelViewModel
        {
            Nombre = "Sofía Martínez",
            Correo = "sofia.martinez@test.com",
            Carrera = "ITD",
            País = "Chile",
            Monedas = 300,
            Progreso = 75
        });

        UsuariosPVM.Add(new UsuarioPanelViewModel
        {
            Nombre = "Luis Hernández",
            Correo = "luis.hernandez@test.com",
            Carrera = "ITC",
            País = "México",
            Monedas = 80,
            Progreso = 75
        });

        UsuariosPVM.Add(new UsuarioPanelViewModel
        {
            Nombre = "Valeria Torres",
            Correo = "valeria.torres@test.com",
            Carrera = "ISC",
            País = "Argentina",
            Monedas = 410,
            Progreso = 100
        });

        UsuariosPVM.Add(new UsuarioPanelViewModel
        {
            Nombre = "Miguel Sánchez",
            Correo = "miguel.sanchez@test.com",
            Carrera = "ITC",
            País = "México",
            Monedas = 180,
            Progreso = 50
        });

        UsuariosPVM.Add(new UsuarioPanelViewModel
        {
            Nombre = "Laura Gómez",
            Correo = "laura.gomez@test.com",
            Carrera = "ITD",
            País = "Colombia",
            Monedas = 220,
            Progreso = 75
        });

        UsuariosPVM.Add(new UsuarioPanelViewModel
        {
            Nombre = "Daniel Castro",
            Correo = "daniel.castro@test.com",
            Carrera = "ISC",
            País = "Perú",
            Monedas = 95,
            Progreso = 25
        });

        UsuariosPVM.Add(new UsuarioPanelViewModel
        {
            Nombre = "Camila Rojas",
            Correo = "camila.rojas@test.com",
            Carrera = "ITC",
            País = "Chile",
            Monedas = 310,
            Progreso = 100
        });

        UsuariosPVM.Add(new UsuarioPanelViewModel
        {
            Nombre = "Fernando Díaz",
            Correo = "fernando.diaz@test.com",
            Carrera = "ITD",
            País = "México",
            Monedas = 140,
            Progreso = 25
        });

        UsuariosPVM.Add(new UsuarioPanelViewModel
        {
            Nombre = "Andrea Morales",
            Correo = "andrea.morales@test.com",
            Carrera = "ISC",
            País = "Argentina",
            Monedas = 275,
            Progreso = 75
        });

        UsuariosPVM.Add(new UsuarioPanelViewModel
        {
            Nombre = "José Ramírez",
            Correo = "jose.ramirez@test.com",
            Carrera = "ITC",
            País = "México",
            Monedas = 60,
            Progreso = 25
        });

        UsuariosPVM.Add(new UsuarioPanelViewModel
        {
            Nombre = "Paula Herrera",
            Correo = "paula.herrera@test.com",
            Carrera = "ITD",
            País = "España",
            Monedas = 350,
            Progreso = 100
        });

        UsuariosPVM.Add(new UsuarioPanelViewModel
        {
            Nombre = "Ricardo Navarro",
            Correo = "ricardo.navarro@test.com",
            Carrera = "ISC",
            País = "México",
            Monedas = 200,
            Progreso = 75
        });

        UsuariosPVM.Add(new UsuarioPanelViewModel
        {
            Nombre = "Elena Vargas",
            Correo = "elena.vargas@test.com",
            Carrera = "ITC",
            País = "Costa Rica",
            Monedas = 125,
            Progreso = 50
        });

        UsuariosPVM.Add(new UsuarioPanelViewModel
        {
            Nombre = "Gabriel Mendoza",
            Correo = "gabriel.mendoza@test.com",
            Carrera = "ITC",
            País = "México",
            Monedas = 210,
            Progreso = 75
        });

        UsuariosPVM.Add(new UsuarioPanelViewModel
        {
            Nombre = "Mariana Silva",
            Correo = "mariana.silva@test.com",
            Carrera = "ITD",
            País = "Uruguay",
            Monedas = 175,
            Progreso = 50
        });

        UsuariosPVM.Add(new UsuarioPanelViewModel
        {
            Nombre = "Pablo Ortega",
            Correo = "pablo.ortega@test.com",
            Carrera = "ISC",
            País = "México",
            Monedas = 90,
            Progreso = 25
        });

        UsuariosPVM.Add(new UsuarioPanelViewModel
        {
            Nombre = "Natalia Cruz",
            Correo = "natalia.cruz@test.com",
            Carrera = "ITC",
            País = "Colombia",
            Monedas = 330,
            Progreso = 100
        });

        UsuariosPVM.Add(new UsuarioPanelViewModel
        {
            Nombre = "Hugo Salazar",
            Correo = "hugo.salazar@test.com",
            Carrera = "ISC",
            País = "Chile",
            Monedas = 140,
            Progreso = 50
        });

        UsuariosPVM.Add(new UsuarioPanelViewModel
        {
            Nombre = "Verónica Paredes",
            Correo = "veronica.paredes@test.com",
            Carrera = "ITD",
            País = "Perú",
            Monedas = 260,
            Progreso = 75
        });

        UsuariosPVM.Add(new UsuarioPanelViewModel
        {
            Nombre = "Sergio Molina",
            Correo = "sergio.molina@test.com",
            Carrera = "ITC",
            País = "México",
            Monedas = 305,
            Progreso = 75
        });



        if (!string.IsNullOrEmpty(busqueda))
        {
            UsuariosPVM = UsuariosPVM.Where(u => u.Nombre.Contains(busqueda) || u.País.Contains(busqueda)).ToList();
        }


        AdminPanelViewModel PanelAdmin = new AdminPanelViewModel();


        PanelAdmin.Usuarios = UsuariosPVM;

        PanelAdmin.TotalUsuarios = UsuariosPVM.Count;


        if (UsuariosPVM.Any())
        {
            PanelAdmin.PromedioMonedas = (int)Math.Round(UsuariosPVM.Average(u => u.Monedas));
            PanelAdmin.PromedioProgreso = (int)Math.Round(UsuariosPVM.Average(u => u.Progreso));
        }
        else
        {
            PanelAdmin.PromedioMonedas = 0;
            PanelAdmin.PromedioProgreso = 0;
        }

         

        int usuariosPorPagina = 10;

        var usuariosPaginados = UsuariosPVM
            .Skip((pagina - 1) * usuariosPorPagina)
            .Take(usuariosPorPagina)
            .ToList();
        
        int totalPaginas = (int)Math.Ceiling((double)UsuariosPVM.Count / usuariosPorPagina);

        PanelAdmin.Usuarios = usuariosPaginados;
        PanelAdmin.PaginaActual = pagina;
        PanelAdmin.TotalPaginas = totalPaginas;




        return View(PanelAdmin);
    }

}