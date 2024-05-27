using FiapHackaton.Domain.Interfaces;
using FiapHackaton.Infrastructure.Data.Context;
using FiapHackaton.Web.Models;

namespace FiapHackaton.Infrastructure.Data.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ApplicationDbContext _context;

        public AppointmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<AppointmentModel> GetAllAppointments()
        {
            return _context.Appointments.ToList();
        }

        public AppointmentModel GetAppointmentById(int id)
        {
            return _context.Appointments.FirstOrDefault(a => a.AppointmentID == id);
        }

        public void AddAppointment(AppointmentModel appointment)
        {
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
        }

        public void UpdateAppointment(AppointmentModel appointment)
        {
            _context.Appointments.Update(appointment);
            _context.SaveChanges();
        }

        public void DeleteAppointment(int id)
        {
            var appointment = _context.Appointments.Find(id);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
                _context.SaveChanges();
            }
        }
    }
}
