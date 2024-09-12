using Backend.Models;
using MongoDB.Driver;

namespace Backend.Repositories
{
    public class ProviderRepo: IRepo<Provider>
    {
        private readonly IMongoCollection<Provider> _providers;
        public ProviderRepo(IMongoClient mongoClient, string databaseName) 
        {
            var database = mongoClient.GetDatabase(databaseName);
            _providers = database.GetCollection<Provider>("Providers");
        }
        public async Task<Provider> GetByIdAsync(string id) =>
            await _providers.Find(provider => provider.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<Provider>> GetAllAsync() =>
            await _providers.Find(provider => true).ToListAsync();

        public async Task CreateAsync(Provider entity) =>
            await _providers.InsertOneAsync(entity);

        public async Task UpdateAsync(string id, Provider entity) =>
            await _providers.ReplaceOneAsync(provider => provider.Id == id, entity);

        public async Task DeleteAsync(string id) =>
            await _providers.DeleteOneAsync(provider => provider.Id == id);
    }
}
