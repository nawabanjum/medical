using FiapHackaton.Application.Interfaces;
using FiapHackaton.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace FiapHackaton.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PatientModel>> GetPatients()
        {
            var patients = _patientService.GetAllPatients();
            return Ok(patients);
        }

        [HttpGet("{id}")]
        public ActionResult<PatientModel> GetPatient(int id)
        {
            var patient = _patientService.GetPatientById(id);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }

        [HttpPost]
        public IActionResult CreatePatient(PatientModel patient)
        {
            _patientService.AddPatient(patient);
            return CreatedAtAction(nameof(GetPatient), new { id = patient.Id }, patient);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePatient(int id, PatientModel patient)
        {
            if (id != patient.Id)
            {
                return BadRequest();
            }

            _patientService.UpdatePatient(patient);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePatient(int id)
        {
            _patientService.DeletePatient(id);
            return NoContent();
        }
    }
}
