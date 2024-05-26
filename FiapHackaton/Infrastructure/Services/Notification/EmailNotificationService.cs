using FiapHackaton.Application.Interfaces;
using FiapHackaton.Domain.Entities;
using FiapHackaton.Domain.Shared;
using FiapHackaton.Web.Models;
using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Net;

namespace FiapHackaton.Infrastructure.Services.Notification
{
    public class EmailNotificationService : INotificationService
    {
        private readonly IOptions<EmailSettings> _options;
        
        public void SendAppointmentReminder(AppointmentModel appointment, string email)
        {
            // Simulação do envio de e-mail de lembrete
            Console.WriteLine($"Enviando e-mail de lembrete para {email}: Sua consulta com o Dr. {appointment.DoctorId} está agendada para {appointment.Date}");
        }

        public void SendPassword(string to, string message)
        {
            sendEmail(to, "Password", message);
        }
        private void sendEmail(string recipient, string subject, string body)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(_options.Value.From, _options.Value.Key),
                EnableSsl = true,

            };
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Send("nawabanjum3.uk@gmail.com", recipient, "subject", body);
        }
    }
}
