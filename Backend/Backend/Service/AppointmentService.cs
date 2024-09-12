using Backend.Models;
using Backend.Repositories;

namespace Backend.Service
{
    public class AppointmentService: IAppointmentService
    {
        private readonly IRepo<Appointment> _appointmentRepository;

        public AppointmentService(IRepo<Appointment> appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsForPatient(string patientId)
        {
            var allAppointments = await _appointmentRepository.GetAllAsync();
            return allAppointments.Where(a => a.PatientId == patientId);
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsForProvider(string providerId)
        {
            var allAppointments = await _appointmentRepository.GetAllAsync();
            return allAppointments.Where(a => a.ProviderId == providerId);
        }

        public async Task<Appointment> BookAppointment(Appointment appointment)
        {
            await _appointmentRepository.CreateAsync(appointment);
            return appointment;
        }

        public async Task<Appointment> UpdateAppointmentStatus(string appointmentId, string status)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(appointmentId);
            if (appointment != null)
            {
                appointment.Status = status;
                await _appointmentRepository.UpdateAsync(appointmentId, appointment);
            }
            return appointment;
        }
    }
}