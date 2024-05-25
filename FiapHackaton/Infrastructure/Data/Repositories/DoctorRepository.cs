using FiapHackaton.Domain.Interfaces;
using FiapHackaton.Infrastructure.Data.Context;
using FiapHackaton.Web.Models;

namespace FiapHackaton.Infrastructure.Data.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ApplicationDbContext _context;

        public DoctorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<DoctorModel> GetAllDoctors()
        {
            return _context.Doctors.ToList();
        }

        public DoctorModel GetDoctorById(int id)
        {
            return _context.Doctors.FirstOrDefault(d => d.Id == id);
        }

        public void AddDoctor(DoctorModel doctor)
        {
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
        }

        public void UpdateDoctor(DoctorModel doctor)
        {
            _context.Doctors.Update(doctor);
            _context.SaveChanges();
        }

        public void DeleteDoctor(int id)
        {
            var doctor = _context.Doctors.Find(id);
            if (doctor != null)
            {
                _context.Doctors.Remove(doctor);
                _context.SaveChanges();
            }
        }
    }
}
