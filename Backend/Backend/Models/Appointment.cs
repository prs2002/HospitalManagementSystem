namespace Backend.Models
{
    public class Appointment
    {
        public string Id { get; set; }
        public string PatientId { get; set; }
        public string ProviderId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
    }

}
