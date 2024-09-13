using Backend.Models;

namespace Backend.Service
{
    public interface IUserService
    {
        Task<User?> LoginAsync(string email, string password);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetUserById(string id);
        Task<User> RegisterUser(User user);
        Task DeleteUserAsync(string id);
        Task UpdateUserAsync(string id, User user);
    }
}
