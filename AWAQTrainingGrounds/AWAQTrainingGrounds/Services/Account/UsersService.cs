using System.Text.Json;
using AWAQTrainingGrounds.Models;

public class UsersService: IUsersService
{
    private readonly HttpClient _httpClient;
     private readonly string _baseURL = "https://127.0.0.1:5550";

    public UsersService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<Users> AddUser(Users user)
    {
        var url = _baseURL + "/users/register";
        var post = JsonSerializer.Serialize(user);

        var content = new StringContent(post, System.Text.Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync(url, content);

        if (!response.IsSuccessStatusCode)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
            {
                Users usuario = new Users();
                usuario.correo = "invalid";
                return usuario;   
            }

            return new Users();
        }

        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<Users>(json) ?? new Users();
       
    }

    public async Task<Users> LoginUser(Users user)
    {  var url = _baseURL + "/users/login";
        var post = JsonSerializer.Serialize(user);

        var content = new StringContent(post, System.Text.Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync(url, content);

        if (!response.IsSuccessStatusCode)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                Users usuario = new Users();
                usuario.correo = "invalid";
                return usuario;   
            }

            return new Users();
        }

        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<Users>(json) ?? new Users();
        
    }

    public async Task<Users> UpdateUser(RegisterViewModel user)
    {
        if (user.user_id != null)
        {
            var url = _baseURL + "/users/" + user.user_id;
            var post = JsonSerializer.Serialize(user);

            var content = new StringContent(post, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(url, content);

            if (!response.IsSuccessStatusCode)
            {
                return new Users();
            }

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Users>(json) ?? new Users();
        } else
        {
            return new Users();
        }
        
    }

    public async Task<List<Countries>> GetCountries()
    {
        var url = _baseURL + "/countries";

        var response = await _httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
        {
            return new List<Countries>();
        }

        var json = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<List<Countries>>(json) ?? new List<Countries>();
    
    }

    public async Task<List<Cosmetic>> GetAvatars()
    {
        var url = _baseURL + "/avatars";

        var response = await _httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
        {
            return new List<Cosmetic>();
        }

        var json = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<List<Cosmetic>>(json) ?? new List<Cosmetic>();
    }

    public async Task<ProfileViewModel> GetProfile(int id)
    {
        var url = _baseURL + "/users/" + id;

        var response = await _httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
        {
            return new ProfileViewModel();
        }

        var json = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<ProfileViewModel>(json) ?? new ProfileViewModel();
    }
}