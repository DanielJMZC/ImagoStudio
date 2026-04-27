using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AWAQTrainingGrounds.Models;

public class TiendaService : ITiendaService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl = "https://127.0.0.1:5550/players";

    public TiendaService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Player> GetPlayer(int playerId)
    {
        var response = await _httpClient.GetAsync($"{_baseUrl}/{playerId}");
        if (!response.IsSuccessStatusCode) return null;
        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<Player>(json);
    }

    public async Task<List<Cosmetic>> GetAllCosmetics()
    {
        var response = await _httpClient.GetAsync($"{_baseUrl}/cosmetics");
        if (!response.IsSuccessStatusCode) return new List<Cosmetic>();
        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<List<Cosmetic>>(json) ?? new List<Cosmetic>();
    }

    public async Task<List<Cosmetic>> GetInventory(int playerId)
    {
        var response = await _httpClient.GetAsync($"{_baseUrl}/{playerId}/inventory");
        if (!response.IsSuccessStatusCode) return new List<Cosmetic>();
        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<List<Cosmetic>>(json) ?? new List<Cosmetic>();
    }

    public async Task<List<Cosmetic>> GetEquipped(int playerId)
    {
        var response = await _httpClient.GetAsync($"{_baseUrl}/{playerId}/equipped");
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Cosmetic>>(content) ?? new List<Cosmetic>();
        }
        return new List<Cosmetic>();
    }

    public async Task<int?> GetPlayerIdByUserId(int userId)
    {
        var response = await _httpClient.GetAsync($"https://127.0.0.1:5550/users/{userId}/player");
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<JsonElement>(content);
            return result.GetProperty("player_id").GetInt32();
        }
        return null;
    }

    public async Task<bool> BuyCosmetic(int playerId, int cosmeticId)
    {
        var payload = new { cosmetic_id = cosmeticId };
        var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync($"{_baseUrl}/{playerId}/buy", content);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> EquipCosmetic(int playerId, int cosmeticId)
    {
        var payload = new { cosmetic_id = cosmeticId };
        var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
        var response = await _httpClient.PutAsync($"{_baseUrl}/{playerId}/equip", content);
        return response.IsSuccessStatusCode;
    }
}
