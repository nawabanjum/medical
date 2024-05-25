using FiapHackaton.Web.Models;

namespace FiapHackaton.Domain.Interfaces
{
    public interface IDoctorRepository
    {
        IEnumerable<DoctorModel> GetAllDoctors();
        DoctorModel GetDoctorById(int id);
        void AddDoctor(DoctorModel doctor);
        void UpdateDoctor(DoctorModel doctor);
        void DeleteDoctor(int id);
    }
}
