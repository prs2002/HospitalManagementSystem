using Backend.Models;

namespace Backend.Service
{
    public interface IUserService
    {
        Task<User> GetUserById(string id);
        Task<User> RegisterUser(User user);
        Task<User> AuthenticateUser(string email, string password);
    }
}
