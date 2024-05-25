using FiapHackaton.Application.Interfaces;
using FiapHackaton.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace FiapHackaton.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DoctorModel>> GetDoctors()
        {
            var doctors = _doctorService.GetAllDoctors();
            return Ok(doctors);
        }

        [HttpGet("{id}")]
        public ActionResult<DoctorModel> GetDoctor(int id)
        {
            var doctor = _doctorService.GetDoctorById(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return Ok(doctor);
        }

        [HttpPost]
        public IActionResult CreateDoctor(DoctorModel doctor)
        {
            _doctorService.AddDoctor(doctor);
            return CreatedAtAction(nameof(GetDoctor), new { id = doctor.Id }, doctor);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDoctor(int id, DoctorModel doctor)
        {
            if (id != doctor.Id)
            {
                return BadRequest();
            }

            _doctorService.UpdateDoctor(doctor);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDoctor(int id)
        {
            _doctorService.DeleteDoctor(id);
            return NoContent();
        }
    }
}
