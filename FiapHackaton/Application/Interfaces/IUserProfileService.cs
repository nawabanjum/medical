using FiapHackaton.Domain.Entities;
using FiapHackaton.Web.Models;

namespace FiapHackaton.Application.Interfaces
{
    public interface IUserProfileService
    {
        Task<IEnumerable<UserProfile>> GetAllUserProfilesAsync();
        Task<IEnumerable<ScheduleModel>> GetAllDoctorsAsync();
        Task<IEnumerable<UserProfile>> GetAllPatientsAsync();
        Task<UserProfile> GetUserProfileByIdAsync(int id);
        Task<UserProfile> LoginAsync(LoginModel model);
        Task<UserProfile> GetByEmail(string email);
        Task RegisterAsync(RegisterModel userProfile);
        Task UpdateUserProfileAsync(UserProfile userProfile);
        Task DeleteUserProfileAsync(int id);
    }
}
