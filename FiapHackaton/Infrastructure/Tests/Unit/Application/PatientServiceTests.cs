using FiapHackaton.Application;
using FiapHackaton.Domain.Interfaces;
using FiapHackaton.Web.Models;
using Moq;
using Xunit;

namespace FiapHackaton.Infrastructure.Tests.Unit.Application
{
    public class PatientServiceTests
    {
        [Fact]
        public void GetAllPatients_ReturnsListOfPatients()
        {
            // Arrange
            var mockPatientRepository = new Mock<IPatientRepository>();
            mockPatientRepository.Setup(repo => repo.GetAllPatients())
                .Returns(new List<PatientModel>
                {
                    new PatientModel { Id = 1, Name = "John Doe", Email = "john@example.com", PhoneNumber = "123456789" },
                    new PatientModel { Id = 2, Name = "Jane Smith", Email = "jane@example.com", PhoneNumber = "987654321" }
                });
            var patientService = new PatientService(mockPatientRepository.Object);

            // Act
            var result = patientService.GetAllPatients();

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<PatientModel>>(result);
            Assert.Collection(result,
                item =>
                {
                    Assert.Equal(1, item.Id);
                    Assert.Equal("John Doe", item.Name);
                    Assert.Equal("john@example.com", item.Email);
                    Assert.Equal("123456789", item.PhoneNumber);
                },
                item =>
                {
                    Assert.Equal(2, item.Id);
                    Assert.Equal("Jane Smith", item.Name);
                    Assert.Equal("jane@example.com", item.Email);
                    Assert.Equal("987654321", item.PhoneNumber);
                });
        }

        // Add more tests for other methods...
    }
}
