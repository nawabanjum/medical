using FiapHackaton.Application.Interfaces;
using FiapHackaton.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace FiapHackaton.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AppointmentModel>> GetAppointments()
        {
            var appointments = _appointmentService.GetAllAppointments();
            return Ok(appointments);
        }

        [HttpGet("{id}")]
        public ActionResult<AppointmentModel> GetAppointment(int id)
        {
            var appointment = _appointmentService.GetAppointmentById(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return Ok(appointment);
        }

        [HttpPost]
        public IActionResult CreateAppointment(AppointmentModel appointment)
        {
            _appointmentService.AddAppointment(appointment);
            return CreatedAtAction(nameof(GetAppointment), new { id = appointment.Id }, appointment);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAppointment(int id, AppointmentModel appointment)
        {
            if (id != appointment.Id)
            {
                return BadRequest();
            }

            _appointmentService.UpdateAppointment(appointment);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult CancelAppointment(int id)
        {
            _appointmentService.CancelAppointment(id);
            return NoContent();
        }
    }
}
