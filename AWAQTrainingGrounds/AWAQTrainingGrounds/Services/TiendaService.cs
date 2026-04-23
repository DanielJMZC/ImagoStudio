using System.Text.Json;
using AWAQTrainingGrounds.Models;

// Conecta la aplicación MVC con la API.
public class TiendaService : ITiendaService
{
    // Lo de las peticiones.
    private readonly HttpClient _httpClient;
    public TiendaService(HttpClient httpClient)
        {
        _httpClient = httpClient;
        }


    public async Task<List<Cosmetic>> obtener_cosmetics()
    {
        // El URL correspondiente (en HTTPS).
        var url = "https://127.0.0.1:5000/players/cosmetics";

        var response = await _httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
        {
            return new List<Cosmetic>(); 
        }
        
        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<List<Cosmetic>>(json) ?? new List<Cosmetic>();
    }

}
