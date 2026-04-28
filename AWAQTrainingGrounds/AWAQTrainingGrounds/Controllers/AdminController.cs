using Microsoft.AspNetCore.Mvc;


public class AdminController : Controller
{

    private readonly IUsuariosService _usuariosService;
    private readonly INPCAdminService _npcService;

    public AdminController(IUsuariosService usuariosService, INPCAdminService npcService)
    {
        _usuariosService = usuariosService;
        _npcService = npcService;
    }


    [AdminOnly]
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

    [AdminOnly]
    public async Task<IActionResult> Juego(int npcId = 1)
    {
        var npcData = await _npcService.GetNPCData(npcId);

        if (npcData == null)
        {
            return NotFound();
        }

        return View("Juego", npcData);
    }

    [HttpPost]
    public async Task<IActionResult> GuardarJuego(NPCAdminViewModel model)
    {
        if (model == null)
        {
            return BadRequest();
        }

        await _npcService.ReplaceDialogosPorNpc(model.NpcId, model.Dialogos);

        await _npcService.ReplacePreguntasPorNpc(model.NpcId, model.Preguntas);

        return RedirectToAction("Juego", new { npcId = model.NpcId });
    }


    [AdminOnly]
    public IActionResult Graficas()
    {
        return View();
    }
}