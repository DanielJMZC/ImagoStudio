using Microsoft.AspNetCore.Mvc;
using AWAQTrainingGrounds.Models;
using AWAQTrainingGrounds.ViewModels;

public class TiendaController : Controller
{
    // El servicio que se conecta con la API REST.
    private readonly ITiendaService _tiendaService;

    private static int puntos_eco = 1000;
    private static string ropa_puesta = "~/images/girlwhite.png";

    // Permitimos consumir el API.
    public TiendaController(ITiendaService tiendaService)
    {
        _tiendaService = tiendaService;
    }

    // Página de la tienda.
    public async Task<IActionResult> Tienda()
    {
        // Obtenemos los cosmeticos de la API.
        var cosmetics = await _tiendaService.obtener_cosmetics();


        // Esto se queda igual como lo tenía antes.
        UsuarioTienda usuario1 = new UsuarioTienda();
        usuario1.UsuarioNombre = "Emma";
        usuario1.PuntosActuales = puntos_eco;
        usuario1.RopaActual = ropa_puesta;

        // Me vi obligada a utilizar un ViewModel para Tienda.cshtml.
        TiendaViewModel vm = new TiendaViewModel();
        vm.Usuario = usuario1;
        vm.Cosmetics = cosmetics;

        return View(vm);
    }

    // Para cuando compramos.
    [HttpPost]
    public async Task<IActionResult> Comprar(string id)
    {
        // Obtenemos los cosmeticos de la API
        var cosmetics = await _tiendaService.obtener_cosmetics();

        // Recorremos la lista para encontrar el objeto que seleccionamos.
        Cosmetic seleccionado = null;
        foreach (var cos in cosmetics)
        {
            if (cos.cosmeticType_id.ToString() == id)
            {
                seleccionado = cos;
            }
        }

        // Si el jugador tiene suficientes monedas, el objeto se compra y equipa.
        if (seleccionado != null)
        {
            if (puntos_eco >= seleccionado.price)
            {
                puntos_eco -= seleccionado.price;
                ropa_puesta = "~/images/" + seleccionado.image_path;
            }
        }

        return RedirectToAction("Tienda");
    }
}