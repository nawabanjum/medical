using FiapHackaton.Application.Interfaces;
using FiapHackaton.Domain.Shared;
using FiapHackaton.Web.Models;
using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Net;
using SendGrid.Helpers.Mail;
using SendGrid;

namespace FiapHackaton.Application
{
    public class NotificationService : INotificationService
    {

        private readonly IOptions<EmailSettings> _options;
        public NotificationService(IOptions<EmailSettings> options)
        {
            _options = options;


        }

        public void SendAppointment(string to, string message)
        {
            sendEmailAsync(to, "Appointment", message);
        }

        public void SendAppointmentReminder(AppointmentModel appointment, string email)
        {
            // Simulação do envio de e-mail de lembrete
            // Console.WriteLine($"Enviando e-mail de lembrete para {email}: Sua consulta com o Dr. {appointment.DoctorId} está agendada para {appointment.Date}");
           
           
        }

        public void SendPassword(string to, string message)
        {
            sendEmailAsync(to, "Password", message);
        }
        private async Task sendEmailAsync(string recipient, string subject, string body)
        {
            var client = new SendGridClient(_options.Value.SendGridKey);
            var from = new EmailAddress(_options.Value.From, _options.Value.From);

            var to = new EmailAddress(recipient, "Dear " + recipient);
            
            var msg = MailHelper.CreateSingleEmail(from, to, subject, body, body);
            var response = await client.SendEmailAsync(msg).ConfigureAwait(false);
            Console.WriteLine(response);
        }
    }
}
