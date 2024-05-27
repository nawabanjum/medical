using FiapHackaton.Application.Interfaces;
using FiapHackaton.Domain.Entities;
using FiapHackaton.Domain.Interfaces;
using FiapHackaton.Web.Models;
using System.Net.Mail;
using System.Net;

namespace FiapHackaton.Application
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IScheduleRepository _scheduleRepository;
        private readonly INotificationService _notificationService;
        private readonly IAppointmentService _appointmentService;
        public UserProfileService(IAppointmentService appointmentService,INotificationService notificationService, IUserProfileRepository userProfileRepository, IScheduleRepository scheduleRepository)
        {
            _userProfileRepository = userProfileRepository;
            _scheduleRepository = scheduleRepository;
            _notificationService = notificationService;
            _appointmentService = appointmentService;
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
            var sc = await _scheduleRepository.GetAllSchedules();
            var app =  _appointmentService.GetAllAppointments().ToList();
            var scheduleTasks = doctorList.Select(async item => new ScheduleModel
            {
                UserName = $"{item.FirstName} {item.LastName}",
                UserId = item.UserId,
                UserTypeId = item.UserTypeId,
                Schedules = sc.Where(a => a.DoctorID == item.UserId).ToList(),
                AppointmentModel = app

            }); ;

            var scheduleModels = await Task.WhenAll(scheduleTasks);
            return scheduleModels.ToList();

        }
        public async Task<IEnumerable<UserProfile>> GetAllPatientsAsync()
        {
            return await _userProfileRepository.GetAllPatientsAsync();
        }

        public async Task<UserProfile> GetByEmail(string email)
        {
            var obj = new UserProfile();
            obj = await _userProfileRepository.GetByEmail(email);
            if (obj != null)
            {
                _notificationService.SendPassword(email, $"He {obj.FirstName} Please use the below password to login {obj.Password}");
            }
            return obj;


        }
    }

      
}
