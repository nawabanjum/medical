using FiapHackaton.Domain.Interfaces;
using FiapHackaton.Infrastructure.Data.Context;
using FiapHackaton.Web.Models;

namespace FiapHackaton.Infrastructure.Data.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext _context;

        public PatientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<PatientModel> GetAllPatients()
        {
            return _context.Patients.ToList();
        }

        public PatientModel GetPatientById(int id)
        {
            return _context.Patients.FirstOrDefault(p => p.Id == id);
        }

        public void AddPatient(PatientModel patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();
        }

        public void UpdatePatient(PatientModel patient)
        {
            _context.Patients.Update(patient);
            _context.SaveChanges();
        }

        public void DeletePatient(int id)
        {
            var patient = _context.Patients.Find(id);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
                _context.SaveChanges();
            }
        }
    }
}
