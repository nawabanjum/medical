//using FiapHackaton.Infrastructure.Data.Context;
//using FiapHackaton.Infrastructure.Data.Repositories;
//using FiapHackaton.Web.Models;
//using Moq;
//using Xunit;

//namespace FiapHackaton.Infrastructure.Tests.Unit.Infrastructure.Data
//{
//    public class DoctorRepositoryTests
//    {
//        [Fact]
//        public void GetAllDoctors_ReturnsListOfDoctors()
//        {
//            // Arrange
//            var mockDbContext = new Mock<ApplicationDbContext>();
//            mockDbContext.Setup(repo => repo.Doctors)
//                .ReturnsDbSet(new List<DoctorModel>
//                {
//                    new DoctorModel { Id = 1, Name = "Dr. Smith", Specialization = "Cardiologist" },
//                    new DoctorModel { Id = 2, Name = "Dr. Johnson", Specialization = "Dermatologist" }
//                });
//            var doctorRepository = new DoctorRepository(mockDbContext.Object);

//            // Act
//            var result = doctorRepository.GetAllDoctors();

//            // Assert
//            Assert.NotNull(result);
//            Assert.IsAssignableFrom<IEnumerable<DoctorModel>>(result);
//            Assert.Collection(result,
//                item =>
//                {
//                    Assert.Equal(1, item.Id);
//                    Assert.Equal("Dr. Smith", item.Name);
//                    Assert.Equal("Cardiologist", item.Specialization);
//                },
//                item =>
//                {
//                    Assert.Equal(2, item.Id);
//                    Assert.Equal("Dr. Johnson", item.Name);
//                    Assert.Equal("Dermatologist", item.Specialization);
//                });
//        }

//        // Add more tests for other methods...
//    }
//}
