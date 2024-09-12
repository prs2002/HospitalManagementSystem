using Backend.Models;

namespace Backend.Service
{
    public interface IAppointmentService
    {
        Task<IEnumerable<Appointment>> GetAppointmentsForPatient(string patientId);
        Task<IEnumerable<Appointment>> GetAppointmentsForProvider(string providerId);
        Task<Appointment> BookAppointment(Appointment appointment);
        Task<Appointment> UpdateAppointmentStatus(string appointmentId, string status);
    }
}
