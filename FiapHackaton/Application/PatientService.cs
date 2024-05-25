using FiapHackaton.Application.Interfaces;
using FiapHackaton.Domain.Interfaces;
using FiapHackaton.Web.Models;

namespace FiapHackaton.Application
{
    public class PatientService: IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public IEnumerable<PatientModel> GetAllPatients()
        {
            return _patientRepository.GetAllPatients();
        }

        public PatientModel GetPatientById(int id)
        {
            return _patientRepository.GetPatientById(id);
        }

        public void AddPatient(PatientModel patient)
        {
            _patientRepository.AddPatient(patient);
        }

        public void UpdatePatient(PatientModel patient)
        {
            _patientRepository.UpdatePatient(patient);
        }

        public void DeletePatient(int id)
        {
            _patientRepository.DeletePatient(id);
        }
    }
}
