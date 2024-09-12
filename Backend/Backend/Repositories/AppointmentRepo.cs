using Backend.Models;
using MongoDB.Driver;

namespace Backend.Repositories
{
    public class AppointmentRepo: IRepo<Appointment>
    {
        private readonly IMongoCollection<Appointment> _appointments;
        public AppointmentRepo(IMongoClient mongoClient, string databaseName)
        {
            var database = mongoClient.GetDatabase(databaseName);
            _appointments = database.GetCollection<Appointment>("Appointments");
        }

        public async Task<Appointment> GetByIdAsync(string id) =>
            await _appointments.Find(appointment  => appointment.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<Appointment>> GetAllAsync() =>
           await _appointments.Find(appointment => true).ToListAsync();

        public async Task CreateAsync(Appointment entity) =>
            await _appointments.InsertOneAsync(entity);

        public async Task UpdateAsync(string id, Appointment entity) =>
            await _appointments.ReplaceOneAsync(appointment => appointment.Id == id, entity);

        public async Task DeleteAsync(string id) =>
            await _appointments.DeleteOneAsync(appointment => appointment.Id == id);

    }
}
