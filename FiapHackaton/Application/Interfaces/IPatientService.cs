using FiapHackaton.Web.Models;

namespace FiapHackaton.Application.Interfaces
{
    public interface IPatientService
    {
        IEnumerable<PatientModel> GetAllPatients();
        PatientModel GetPatientById(int id);
        void AddPatient(PatientModel patient);
        void UpdatePatient(PatientModel patient);
        void DeletePatient(int id);
    }
}
