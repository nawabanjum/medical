using FiapHackaton.Web.Models;

namespace FiapHackaton.Application.Interfaces
{
    public interface INotificationService
    {
        void SendAppointmentReminder(AppointmentModel appointment, string email);
    }
}
