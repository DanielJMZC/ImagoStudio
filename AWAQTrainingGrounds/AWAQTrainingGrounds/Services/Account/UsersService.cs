using System.Text.Json;

public class UsersService: IUsersService
{
    private readonly HttpClient _httpClient;

    public UsersService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<Users> AddUser(Users user)
    {
        var url = "https://127.0.0.1:5550/users/register";
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
    {  var url = "https://127.0.0.1:5550/users/login";
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
            var url = "https://127.0.0.1:5550/users/" + user.user_id;
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
}