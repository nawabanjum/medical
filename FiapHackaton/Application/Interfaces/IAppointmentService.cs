using FiapHackaton.Web.Models;

namespace FiapHackaton.Application.Interfaces
{
    public interface IAppointmentService
    {
        IEnumerable<AppointmentModel> GetAllAppointments();
        AppointmentModel GetAppointmentById(int id);
        void AddAppointment(AppointmentModel appointment);
        void UpdateAppointment(AppointmentModel appointment);
        void CancelAppointment(int id);
    }
}
