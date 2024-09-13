using Backend.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Backend.Repositories
{
    public class AppointmentRepo: IRepo<Appointment>
    {
        private readonly IMongoCollection<Appointment> _appointments;
        private readonly MongoDbSettings _settings;

        public AppointmentRepo(IOptions<MongoDbSettings> settings)
        {
            _settings = settings.Value;
            var client = new MongoClient(_settings.ConnectionString);
            var database = client.GetDatabase(_settings.DatabaseName);
            _appointments = database.GetCollection<Appointment>(_settings.AppointmentsCollection);
        }

        public async Task<Appointment> GetByIdAsync(string id) =>
            await _appointments.Find(appointment  => appointment.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<Appointment>> GetAllAsync() =>
           await _appointments.Find(appointment => true).ToListAsync();

        public async Task<Appointment> CreateAsync(Appointment entity)
        {
            await _appointments.InsertOneAsync(entity);
            return entity;
        }

        public Task<Appointment> FindByEmailAsync(string email)
        {
            return Task.FromResult<Appointment>(null);
        }

        public async Task UpdateAsync(string id, Appointment entity) =>
            await _appointments.ReplaceOneAsync(appointment => appointment.Id == id, entity);

        public async Task DeleteAsync(string id) =>
            await _appointments.DeleteOneAsync(appointment => appointment.Id == id);

    }
}
