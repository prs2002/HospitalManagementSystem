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

        public Task<IEnumerable<User>> GetAllAsync()
        {
            return _userRepository.GetAllAsync();
        }
        public async Task<User?> LoginAsync(string email, string password)
        {
            var user = await _userRepository.FindByEmailAsync(email);
            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                return user;
            }
            return null;
        }
        public async Task<User> GetUserById(string id) =>
           await _userRepository.GetByIdAsync(id);

        public Task<User> RegisterUser(User user)
        {
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
            return _userRepository.CreateAsync(user);
        }

        public Task UpdateUserAsync(string id, User user)
        {
            return _userRepository.UpdateAsync(id, user);
        }

        public Task DeleteUserAsync(string id)
        {
            return _userRepository.DeleteAsync(id);
        }

    }
}
