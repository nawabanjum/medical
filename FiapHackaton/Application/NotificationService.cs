using FiapHackaton.Application.Interfaces;
using FiapHackaton.Web.Models;

namespace FiapHackaton.Application
{
    public class NotificationService : INotificationService
    {
        public void SendAppointmentReminder(AppointmentModel appointment, string email)
        {
            // Implementação para enviar um lembrete de consulta por e-mail
            Console.WriteLine($"Sending appointment reminder to {email}: Your appointment with Dr. {appointment.DoctorId} is scheduled for {appointment.Date}");
        }
    }
}
