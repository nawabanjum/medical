//using FiapHackaton.Infrastructure.Data.Context;
//using FiapHackaton.Infrastructure.Data.Repositories;
//using FiapHackaton.Web.Models;
//using Moq;
//using Xunit;

//namespace FiapHackaton.Infrastructure.Tests.Unit.Infrastructure.Data
//{
//    public class PatientRepositoryTests
//    {
//        [Fact]
//        public void GetAllPatients_ReturnsListOfPatients()
//        {
//            // Arrange
//            var mockDbContext = new Mock<ApplicationDbContext>();
//            mockDbContext.Setup(repo => repo.Patients)
//                .ReturnsDbSet(
//                [
//                    new PatientModel { Id = 1, Name = "John Doe", Email = "john@example.com", PhoneNumber = "123456789" },
//                    new PatientModel { Id = 2, Name = "Jane Smith", Email = "jane@example.com", PhoneNumber = "987654321" }
//                ]);
//            var patientRepository = new PatientRepository(mockDbContext.Object);

//            // Act
//            var result = patientRepository.GetAllPatients();

//            // Assert
//            Assert.NotNull(result);
//            Assert.IsAssignableFrom<IEnumerable<PatientModel>>(result);
//            Assert.Collection(result,
//                item =>
//                {
//                    Assert.Equal(1, item.Id);
//                    Assert.Equal("John Doe", item.Name);
//                    Assert.Equal("john@example.com", item.Email);
//                    Assert.Equal("123456789", item.PhoneNumber);
//                },
//                item =>
//                {
//                    Assert.Equal(2, item.Id);
//                    Assert.Equal("Jane Smith", item.Name);
//                    Assert.Equal("jane@example.com", item.Email);
//                    Assert.Equal("987654321", item.PhoneNumber);
//                });
//        }

//        // Add more tests for other methods...
//    }
//}
