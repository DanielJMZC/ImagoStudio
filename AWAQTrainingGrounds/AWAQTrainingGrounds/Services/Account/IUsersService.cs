using AWAQTrainingGrounds.Models;

public interface IUsersService
{
    Task<RegViewModel> AddUser(Users user);
    Task<LoginViewModel> LoginUser(Users user);

    Task<Users> UpdateUser(RegisterViewModel users);

    Task<List<Countries>> GetCountries();

    Task<ProfileViewModel> GetProfile(int id);

    Task<List<Cosmetic>> GetAvatars();
    Task<bool> IsAdmin(int userId);
}