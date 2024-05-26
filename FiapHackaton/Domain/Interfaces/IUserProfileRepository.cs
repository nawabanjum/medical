using FiapHackaton.Domain.Entities;
using FiapHackaton.Web.Models;

namespace FiapHackaton.Domain.Interfaces
{
    public interface IUserProfileRepository
    {
        Task<IEnumerable<UserProfile>> GetAllAsync();
        Task<IEnumerable<UserProfile>> GetAllDoctorsAsync();
        Task<IEnumerable<UserProfile>> GetAllPatientsAsync();
        Task<UserProfile> GetByIdAsync(int id);
        Task<UserProfile> LoginAsync(LoginModel userProfile);
        Task AddAsync(UserProfile userProfile);
        Task UpdateAsync(UserProfile userProfile);
        Task DeleteAsync(int id);

        Task<UserProfile> GetByEmail(string email);
    }
}
