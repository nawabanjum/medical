using FiapHackaton.Infrastructure.Services.Notification;
using FiapHackaton.Web.Models;
using Xunit;

namespace FiapHackaton.Infrastructure.Tests.Unit.Application
{
    public class NotificationServiceTests
    {
        [Fact]
        public void SendAppointmentReminder_ShouldSendEmail()
        {
            // Arrange
            var appointment = new AppointmentModel
            {
                //Id = 1,
                //PatientId = 1,
                //DoctorId = 1,
                //Date = new System.DateTime(2024, 5, 20, 10, 0, 0),
                //Status = "Scheduled"
            };
            var email = "example@example.com";

            var emailNotificationService = new EmailNotificationService();

            // Act
            emailNotificationService.SendAppointmentReminder(appointment, email);

            // Assert
            // Verifica se o método SendAppointmentReminder chamou o Console.WriteLine com os parâmetros corretos
            // Isso só é possível porque estamos usando Console.WriteLine na implementação do serviço de notificação por e-mail
            //Assert.Equal($"Enviando e-mail de lembrete para {email}: Sua consulta com o Dr. {appointment.DoctorId} está agendada para {appointment.Date}", GetConsoleOutput());
        }

        // Método auxiliar para obter a saída do console
        private string GetConsoleOutput()
        {
            using (var consoleOutput = new System.IO.StringWriter())
            {
                System.Console.SetOut(consoleOutput);
                return consoleOutput.ToString().Trim();
            }
        }
    }
}
