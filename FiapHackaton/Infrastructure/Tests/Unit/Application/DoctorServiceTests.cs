using FiapHackaton.Application;
using FiapHackaton.Domain.Interfaces;
using FiapHackaton.Web.Models;
using Moq;
using Xunit;

namespace FiapHackaton.Infrastructure.Tests.Unit.Application
{
    public class DoctorServiceTests
    {
        [Fact]
        public void GetAllDoctors_ReturnsListOfDoctors()
        {
            // Arrange
            var mockDoctorRepository = new Mock<IDoctorRepository>();
            mockDoctorRepository.Setup(repo => repo.GetAllDoctors())
                .Returns(new List<DoctorModel>
                {
                    new DoctorModel { Id = 1, Name = "Dr. Smith", Specialization = "Cardiologist" },
                    new DoctorModel { Id = 2, Name = "Dr. Johnson", Specialization = "Dermatologist" }
                });
            var doctorService = new DoctorService(mockDoctorRepository.Object);

            // Act
            var result = doctorService.GetAllDoctors();

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<DoctorModel>>(result);
            Assert.Collection(result,
                item =>
                {
                    Assert.Equal(1, item.Id);
                    Assert.Equal("Dr. Smith", item.Name);
                    Assert.Equal("Cardiologist", item.Specialization);
                },
                item =>
                {
                    Assert.Equal(2, item.Id);
                    Assert.Equal("Dr. Johnson", item.Name);
                    Assert.Equal("Dermatologist", item.Specialization);
                });
        }

        // Add more tests for other methods...
    }
}
