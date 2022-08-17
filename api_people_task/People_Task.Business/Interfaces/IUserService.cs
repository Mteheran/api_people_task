public interface IUserService
{
    Task<bool> CreateUser(User user);
    Task<IEnumerable<User>> GetUsers();
    Task<User> GetUser(int userId);
    Task<User> UpdateUser(User user);
    Task<bool> DeleteUser(int userId);
}