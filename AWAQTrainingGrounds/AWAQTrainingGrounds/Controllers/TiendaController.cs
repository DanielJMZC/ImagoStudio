using Microsoft.AspNetCore.Mvc;
using AWAQTrainingGrounds.Models;

public class TiendaController : Controller
{
    // Empieza lo de Andrea - Sistema de gastar los puntos.

    private static int puntos_eco = 1000;
    private static string ropa_puesta = "~/images/girlwhite.png";

    // Lista de objetos de la tienda.
    private static List<ObjectoTienda> listaObjetos = new List<ObjectoTienda>
    {
        new ObjectoTienda { IDObjecto = "1", ObjectoNombre = "Camisa roja",   Precio = 80,  SeCompro = false },
        new ObjectoTienda { IDObjecto = "2", ObjectoNombre = "Camisa naranja",Precio = 100, SeCompro = false },
        new ObjectoTienda { IDObjecto = "3", ObjectoNombre = "Camisa amarilla",Precio = 150,SeCompro = false },
        new ObjectoTienda { IDObjecto = "4", ObjectoNombre = "Camisa verde",  Precio = 200, SeCompro = false },
        new ObjectoTienda { IDObjecto = "5", ObjectoNombre = "Camisa azul",   Precio = 250, SeCompro = false },
        new ObjectoTienda { IDObjecto = "6", ObjectoNombre = "Camisa morada", Precio = 300, SeCompro = false }
    };

    public IActionResult Tienda()
    {
        UsuarioTienda usuario1 = new UsuarioTienda();
        usuario1.UsuarioNombre = "Emma";
        usuario1.PuntosActuales = puntos_eco;
        usuario1.RopaActual = ropa_puesta;

        return View(usuario1);
    }

[HttpPost]
public IActionResult Comprar(string GastarPuntos)
{
    ObjectoTienda objetoSeleccionado = null;

    // Buscar el objeto en la lista
    foreach (ObjectoTienda obj in listaObjetos)
    {
        if (obj.IDObjecto == GastarPuntos)
        {
            objetoSeleccionado = obj;
        }
    }

    if (objetoSeleccionado != null)
    {
        if (objetoSeleccionado.SeCompro == false && puntos_eco > objetoSeleccionado.Precio)
        {
            puntos_eco = puntos_eco - objetoSeleccionado.Precio;
            objetoSeleccionado.SeCompro = true;

            if (objetoSeleccionado.IDObjecto == "1")
            {
                ropa_puesta = "~/images/girlred.png";
            }
            else if (objetoSeleccionado.IDObjecto == "2")
            {
                ropa_puesta = "~/images/girlorange.png";
            }
            else if (objetoSeleccionado.IDObjecto == "3")
            {
                ropa_puesta = "~/images/girlyellow.png";
            }
            else if (objetoSeleccionado.IDObjecto == "4")
            {
                ropa_puesta = "~/images/girlgreen.png";
            }
            else if (objetoSeleccionado.IDObjecto == "5")
            {
                ropa_puesta = "~/images/girlblue.png";
            }
            else if (objetoSeleccionado.IDObjecto == "6")
            {
                ropa_puesta = "~/images/girlpurple.png";
            }
        }
    }

    return RedirectToAction("Tienda");
}
    // Termina lo de Andrea.
}