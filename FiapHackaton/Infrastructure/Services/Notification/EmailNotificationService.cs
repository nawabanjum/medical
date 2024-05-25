using FiapHackaton.Application.Interfaces;
using FiapHackaton.Domain.Entities;
using FiapHackaton.Web.Models;

namespace FiapHackaton.Infrastructure.Services.Notification
{
    public class EmailNotificationService : INotificationService
    {
        public void SendAppointmentReminder(AppointmentModel appointment, string email)
        {
            // Simulação do envio de e-mail de lembrete
            Console.WriteLine($"Enviando e-mail de lembrete para {email}: Sua consulta com o Dr. {appointment.DoctorId} está agendada para {appointment.Date}");
        }
    }
}
