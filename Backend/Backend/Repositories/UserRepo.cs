using Backend.Models;
using Backend.Repositories;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Repositories
{
    public class UserRepo : IRepo<User>
    {
        private readonly IMongoCollection<User> _users;
        public UserRepo(IMongoDatabase database, MongoDbSettings settings)
        {
            _users = database.GetCollection<User>(settings.UsersCollection);
        }

        public async Task<User> GetByIdAsync(string id) =>
            await _users.Find(user => user.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<User>> GetAllAsync() =>
            await _users.Find(user => true).ToListAsync();

        public async Task<User> CreateAsync(User entity)
        {
            await _users.InsertOneAsync(entity);
            return entity;
        }

        public async Task UpdateAsync(string id, User entity) =>
            await _users.ReplaceOneAsync(user => user.Id == id, entity);

        public async Task DeleteAsync(string id) =>
            await _users.DeleteOneAsync(user => user.Id == id);

        public Task<User> FindByEmailAsync(string email)
        {
            return _users.Find(c => c.Email == email).FirstOrDefaultAsync();
        }
    }
}
