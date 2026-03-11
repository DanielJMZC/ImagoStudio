using Microsoft.AspNetCore.Mvc.Rendering;

public class UsuarioPanelViewModel
{
    public string Nombre { get; set; }
    public string Correo { get; set; }
    public string Carrera { get; set; }
    public string País { get; set; }
    public int Monedas { get; set; }
    public int Progreso { get; set; }
    
}