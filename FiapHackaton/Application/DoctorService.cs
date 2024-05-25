using FiapHackaton.Application.Interfaces;
using FiapHackaton.Domain.Interfaces;
using FiapHackaton.Web.Models;

namespace FiapHackaton.Application
{
    public class DoctorService: IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public IEnumerable<DoctorModel> GetAllDoctors()
        {
            return _doctorRepository.GetAllDoctors();
        }

        public DoctorModel GetDoctorById(int id)
        {
            return _doctorRepository.GetDoctorById(id);
        }

        public void AddDoctor(DoctorModel doctor)
        {
            _doctorRepository.AddDoctor(doctor);
        }

        public void UpdateDoctor(DoctorModel doctor)
        {
            _doctorRepository.UpdateDoctor(doctor);
        }

        public void DeleteDoctor(int id)
        {
            _doctorRepository.DeleteDoctor(id);
        }
    }
}
