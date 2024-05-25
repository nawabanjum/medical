using FiapHackaton.Web.Models;

namespace FiapHackaton.Application.Interfaces
{
    public interface IDoctorService
    {
        IEnumerable<DoctorModel> GetAllDoctors();
        DoctorModel GetDoctorById(int id);
        void AddDoctor(DoctorModel doctor);
        void UpdateDoctor(DoctorModel doctor);
        void DeleteDoctor(int id);
    }
}
