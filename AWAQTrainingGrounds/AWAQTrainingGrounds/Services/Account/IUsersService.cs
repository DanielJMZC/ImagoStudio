public interface IUsersService
{
    Task<Users> AddUser(Users user);
    Task<Users> LoginUser(Users user);

    Task<Users> UpdateUser(RegisterViewModel users);
}