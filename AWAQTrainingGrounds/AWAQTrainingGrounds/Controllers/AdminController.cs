using Microsoft.AspNetCore.Mvc;


public class AdminController : Controller
{

    private readonly IUsuariosService _usuariosService;


    public AdminController(IUsuariosService usuariosService)
    {
        _usuariosService = usuariosService;
    }


    public async Task<IActionResult> Panel(string busqueda, int pagina = 1)
    {

        int pageSize = 10;


        var usuariosResponse = await _usuariosService.GetUsuarios(pagina, pageSize, busqueda ?? "");
        var stats = await _usuariosService.GetEstadisticas();


        var vm = new AdminUsuariosViewModel
        {
            Usuarios = new UsuariosResponseViewModel
            {

                data = usuariosResponse.data.Select(u => new UsuarioResumenViewModel
                {
                    nombre = $"{u.nombre} {u.apellido}",
                    correo = u.correo,
                    pais = u.pais,
                    monedas = u.monedas,
                    progreso = u.progreso
                }).ToList(),


                page = usuariosResponse.page,
                pageSize = usuariosResponse.pageSize,
                total = usuariosResponse.total,
                totalPages = usuariosResponse.totalPages
            },


            Estadisticas = new EstadisticasViewModel
            {
                totalUsuarios = stats.totalUsuarios,
                promedioMonedas = stats.promedioMonedas,
                promedioProgreso = stats.promedioProgreso
            }
        };
        

        return View(vm);
    }
}