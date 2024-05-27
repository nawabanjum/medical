using FiapHackaton.Application;
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
        private readonly IScheduleService _scheduleService;
        private readonly IUserProfileService _userProfileService;
        private readonly INotificationService _notificationService;
        public AppointmentController(INotificationService notificationService,IUserProfileService userProfileService, IScheduleService scheduleService,IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
            _scheduleService = scheduleService;
            _userProfileService = userProfileService;
            _notificationService = notificationService;
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
        public async Task<IActionResult> CreateAppointmentAsync(AppointmentModel appointment)
        {
            await _appointmentService.AddAppointmentAsync(appointment);
            var schedule = await _scheduleService.GetScheduleById(appointment.ScheduleID);
            var dProfile = await _userProfileService.GetUserProfileByIdAsync(appointment.DoctorId);
            var Pprofile = await _userProfileService.GetUserProfileByIdAsync(appointment.PatientId);
            if (schedule != null)
            {
                string message = $"Dear Dr {dProfile.FirstName} , you have an appointment for the day {schedule.DayOfWeek} at {schedule.StartTime} to {schedule.EndTime} with Patient {Pprofile.FirstName}";
                _notificationService.SendAppointment(dProfile.Email, message);
            }
            return CreatedAtAction(nameof(GetAppointment), new { id = appointment.AppointmentID }, appointment);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAppointment(int id, AppointmentModel appointment)
        {
            if (id != appointment.AppointmentID)
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
