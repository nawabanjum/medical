using FiapHackaton.Application;
using FiapHackaton.Domain.Interfaces;
using FiapHackaton.Web.Models;
using Moq;
using Xunit;

namespace FiapHackaton.Infrastructure.Tests.Unit.Application
{
    public class AppointmentServiceTests
    {
        [Fact]
        public void GetAllAppointments_ReturnsListOfAppointments()
        {
            // Arrange
            //var mockAppointmentRepository = new Mock<IAppointmentRepository>();
            //mockAppointmentRepository.Setup(repo => repo.GetAllAppointments())
            //    .Returns(new List<AppointmentModel>
            //    {
            //        new AppointmentModel { Id = 1, PatientId = 1, DoctorId = 1, Date = DateTime.Now.AddDays(1), Status = "Scheduled" },
            //        new AppointmentModel { Id = 2, PatientId = 2, DoctorId = 2, Date = DateTime.Now.AddDays(2), Status = "Scheduled" }
            //    });
            //var appointmentService = new AppointmentService(mockAppointmentRepository.Object);

            //// Act
            //var result = appointmentService.GetAllAppointments();

            //// Assert
            //Assert.NotNull(result);
            //Assert.IsAssignableFrom<IEnumerable<AppointmentModel>>(result);
            //Assert.Collection(result,
            //    item =>
            //    {
            //        Assert.Equal(1, item.Id);
            //        Assert.Equal(1, item.PatientId);
            //        Assert.Equal(1, item.DoctorId);
            //        Assert.Equal(DateTime.Now.AddDays(1).Date, item.Date.Date);
            //        Assert.Equal("Scheduled", item.Status);
            //    },
            //    item =>
            //    {
            //        Assert.Equal(2, item.AppointmentID);
            //        Assert.Equal(2, item.PatientId);
            //        Assert.Equal(2, item.DoctorId);
            //        Assert.Equal(DateTime.Now.AddDays(2).Date, item.Date.Date);
            //        Assert.Equal("Scheduled", item.Status);
               // });
        }

        // Add more tests for other methods...
    }
}
