using FiapHackaton.Application.Interfaces;
using FiapHackaton.Domain.Entities;
using FiapHackaton.Domain.Shared;
using FiapHackaton.Web.Models;
using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Net;
using SendGrid.Helpers.Mail;
using SendGrid;

namespace FiapHackaton.Infrastructure.Services.Notification
{
    public class EmailNotificationService : INotificationService
    {
        private readonly IOptions<EmailSettings> _options;

        public void SendAppointment(string to, string message)
        {
            throw new NotImplementedException();
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
            //var smtpClient = new SmtpClient("smtp.gmail.com")
            //{
            //    Port = 587,
            //    Credentials = new NetworkCredential(_options.Value.From, _options.Value.Key),
            //    EnableSsl = true,

            //};
            //smtpClient.UseDefaultCredentials = false;
            //smtpClient.Send("nawabanjum3.uk@gmail.com", recipient, "subject", body);


            var client = new SendGridClient(_options.Value.SendGridKey);
            var from = new EmailAddress(_options.Value.From, _options.Value.From);
            var to = new EmailAddress(recipient, "Dear "+ recipient);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, body, body);
            var response = await client.SendEmailAsync(msg).ConfigureAwait(false);
        }
    }
}
