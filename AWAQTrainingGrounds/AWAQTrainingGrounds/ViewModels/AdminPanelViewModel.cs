using Microsoft.AspNetCore.Mvc.Rendering;

public class AdminPanelViewModel
{
    public List<UsuarioPanelViewModel> Usuarios { get; set; }
    
    public int TotalUsuarios { get; set; }
    public int PromedioMonedas { get; set; }
    public int PromedioProgreso { get; set; }

    public int PaginaActual { get; set; }
    public int TotalPaginas { get; set; }
}