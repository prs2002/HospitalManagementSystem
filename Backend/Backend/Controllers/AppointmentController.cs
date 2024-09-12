using Backend.Models;
using Backend.Service;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet("patient/{patientId}")]
        public async Task<IActionResult> GetAppointmentsForPatient(string patientId)
        {
            var appointments = await _appointmentService.GetAppointmentsForPatient(patientId);
            return Ok(appointments);
        }

        [HttpGet("provider/{providerId}")]
        public async Task<IActionResult> GetAppointmentsForProvider(string providerId)
        {
            var appointments = await _appointmentService.GetAppointmentsForProvider(providerId);
            return Ok(appointments);
        }

        [HttpPost]
        public async Task<IActionResult> BookAppointment(Appointment appointment)
        {
            var bookedAppointment = await _appointmentService.BookAppointment(appointment);
            return CreatedAtAction(nameof(GetAppointmentsForPatient), new { patientId = bookedAppointment.PatientId }, bookedAppointment);
        }

        [HttpPatch("{appointmentId}")]
        public async Task<IActionResult> UpdateAppointmentStatus(string appointmentId, [FromBody] string status)
        {
            var updatedAppointment = await _appointmentService.UpdateAppointmentStatus(appointmentId, status);
            if (updatedAppointment == null)
                return NotFound();

            return Ok(updatedAppointment);
        }
    }
}
