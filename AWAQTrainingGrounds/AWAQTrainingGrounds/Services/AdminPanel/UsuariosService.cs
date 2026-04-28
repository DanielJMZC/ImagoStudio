using System.Net.Http.Json;

public class UsuariosService : IUsuariosService
{
    private readonly HttpClient _httpClient;

    public UsuariosService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<UsuariosResponseViewModel> GetUsuarios(int page, int pageSize, string search)
    {
        var url = $"http://127.0.0.1:5000/users/summary?page={page}&pageSize={pageSize}&search={search}";
        
        var response = await _httpClient.GetFromJsonAsync<UsuariosResponseViewModel>(url);

        return response;
    }

    public async Task<EstadisticasViewModel> GetEstadisticas()
    {
        var response = await _httpClient.GetFromJsonAsync<EstadisticasViewModel>("http://127.0.0.1:5000/users/stats");

        return response;
    }
}