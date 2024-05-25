using FiapHackaton.Web.Models;

namespace FiapHackaton.Domain.Interfaces
{
    public interface IAppointmentRepository
    {
        IEnumerable<AppointmentModel> GetAllAppointments();
        AppointmentModel GetAppointmentById(int id);
        void AddAppointment(AppointmentModel appointment);
        void UpdateAppointment(AppointmentModel appointment);
        void DeleteAppointment(int id);
    }
}
