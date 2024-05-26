using FiapHackaton.Application.Interfaces;
using FiapHackaton.Domain.Entities;
using FiapHackaton.Domain.Interfaces;
using FiapHackaton.Web.Models;

namespace FiapHackaton.Application
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IScheduleRepository  _scheduleRepository ;
        
        public UserProfileService(IUserProfileRepository userProfileRepository, IScheduleRepository scheduleRepository)
        {
            _userProfileRepository = userProfileRepository;
            _scheduleRepository = scheduleRepository;
        }

        public async Task<IEnumerable<UserProfile>> GetAllUserProfilesAsync()
        {
            return await _userProfileRepository.GetAllAsync();
        }

        public async Task<UserProfile> GetUserProfileByIdAsync(int id)
        {
            return await _userProfileRepository.GetByIdAsync(id);
        }

        public async Task RegisterAsync(RegisterModel model)
        {
            try
            {


                var obj = new UserProfile
                {
                    CreatedAt = DateTime.UtcNow,
                    Description = string.Empty,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Password = model.Password,
                    PhoneNumber = string.Empty,
                    UserTypeId = model.UserTypeId,
                    UpdatedAt = DateTime.UtcNow
                };

                await _userProfileRepository.AddAsync(obj);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                throw;
            }
        }

        public async Task UpdateUserProfileAsync(UserProfile userProfile)
        {
            var obj = new UserProfile();

            if (userProfile.UserId > 0)
            {
                obj = await _userProfileRepository.GetByIdAsync(userProfile.UserId);
                if (obj != null)
                {
                    obj.PhoneNumber = userProfile.PhoneNumber;
                    obj.FirstName = userProfile.FirstName;
                    obj.LastName = userProfile.LastName;
                    obj.UpdatedAt = DateTime.UtcNow;
                    obj.Description = userProfile.Description;
                    obj.Email = userProfile.Email;

                    await _userProfileRepository.UpdateAsync(obj);
                }
            }

        }

        public async Task DeleteUserProfileAsync(int id)
        {
            await _userProfileRepository.DeleteAsync(id);
        }
        public async Task<UserProfile> LoginAsync(LoginModel model)
        {
            return await _userProfileRepository.LoginAsync(model);
        }
        public async Task<IEnumerable<ScheduleModel>> GetAllDoctorsAsync()
        {
            var doctorList = await _userProfileRepository.GetAllDoctorsAsync();
            var scheduleTasks = doctorList.Select(async item => new ScheduleModel
            {
                UserName = $"{item.FirstName} {item.LastName}",
                UserId = item.UserId,
                UserTypeId = item.UserTypeId,
                Schedules = await _scheduleRepository.GetScheduleByUserId(item.UserId)
            });

            var scheduleModels = await Task.WhenAll(scheduleTasks);
            return scheduleModels.ToList();

        }
        public async Task<IEnumerable<UserProfile>> GetAllPatientsAsync()
        {
            return await _userProfileRepository.GetAllPatientsAsync();
        }
    }
}
