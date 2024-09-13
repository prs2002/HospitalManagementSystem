using Backend.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Backend.Repositories
{
    public class ProviderRepo: IRepo<Provider>
    {
        private readonly IMongoCollection<Provider> _providers;
        private readonly MongoDbSettings _settings;
        public ProviderRepo(IOptions<MongoDbSettings> settings) 
        {
            _settings = settings.Value;
            var client = new MongoClient(_settings.ConnectionString);
            var database = client.GetDatabase(_settings.DatabaseName);
            _providers = database.GetCollection<Provider>(_settings.ProvidersCollection);
        }
        public async Task<Provider> GetByIdAsync(string id) =>
            await _providers.Find(provider => provider.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<Provider>> GetAllAsync() =>
            await _providers.Find(provider => true).ToListAsync();

        public async Task<Provider> CreateAsync(Provider entity)
        {
            await _providers.InsertOneAsync(entity);
            return entity;
        }
        public Task<Provider> FindByEmailAsync(string email)
        {
            return _providers.Find(c => c.Email == email).FirstOrDefaultAsync();
        }
        public async Task UpdateAsync(string id, Provider entity) =>
            await _providers.ReplaceOneAsync(provider => provider.Id == id, entity);

        public async Task DeleteAsync(string id) =>
            await _providers.DeleteOneAsync(provider => provider.Id == id);
    }
}
