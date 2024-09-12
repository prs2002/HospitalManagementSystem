using Backend.Models;
using Backend.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Backend.Service
{
    public class UserService: IUserService
    {
        private readonly IRepo<User> _userRepository;
        public UserService(IRepo<User> userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> GetUserById(string id) =>
           await _userRepository.GetByIdAsync(id);

        public async Task<User> RegisterUser(User user)
        {
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
            await _userRepository.CreateAsync(user);
            return user;
        }

        public async Task<User> AuthenticateUser(string email, string password)
        {
            var user = await _userRepository.GetAllAsync();
            var authUser = user.FirstOrDefault(u => u.Email == email && BCrypt.Net.BCrypt.Verify(u.PasswordHash, password));
            return authUser;
        }
    }
}
