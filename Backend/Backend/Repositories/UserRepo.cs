using Backend.Models;
using Backend.Repositories;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Repositories
{
    public class UserRepo : IRepo<User>
    {
        private readonly IMongoCollection<User> _users;

        public UserRepo(IMongoClient mongoClient, string databaseName)
        {
            var database = mongoClient.GetDatabase(databaseName);
            _users = database.GetCollection<User>("Users");
        }

        public async Task<User> GetByIdAsync(string id) =>
            await _users.Find(user => user.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<User>> GetAllAsync() =>
            await _users.Find(user => true).ToListAsync();

        public async Task CreateAsync(User entity) =>
            await _users.InsertOneAsync(entity);

        public async Task UpdateAsync(string id, User entity) =>
            await _users.ReplaceOneAsync(user => user.Id == id, entity);

        public async Task DeleteAsync(string id) =>
            await _users.DeleteOneAsync(user => user.Id == id);
    }
}
