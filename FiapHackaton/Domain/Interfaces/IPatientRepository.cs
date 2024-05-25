using FiapHackaton.Web.Models;

namespace FiapHackaton.Domain.Interfaces
{
    public interface IPatientRepository
    {
        IEnumerable<PatientModel> GetAllPatients();
        PatientModel GetPatientById(int id);
        void AddPatient(PatientModel patient);
        void UpdatePatient(PatientModel patient);
        void DeletePatient(int id);
    }
}
