using FiapHackaton.Application.Interfaces;
using FiapHackaton.Domain.Entities;
using FiapHackaton.Domain.Interfaces;
using FiapHackaton.Web.Models;

namespace FiapHackaton.Application
{
	public class UserProfileService : IUserProfileService
	{
		private readonly IUserProfileRepository _userProfileRepository;
		public UserProfileService(IUserProfileRepository userProfileRepository)
		{
			_userProfileRepository = userProfileRepository;
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
			var obj = new UserProfile{
				CreatedAt = DateTime.UtcNow,
				Description = string.Empty,
				Email = model.Email,
				FirstName = model.FirstName,
				LastName = model.LastName,
				Password = model.Password,
				PhoneNumber = string.Empty,
				UserTypeId = model.UserTypeId
			};

			await _userProfileRepository.AddAsync(obj);
		}

		public async Task UpdateUserProfileAsync(UserProfile userProfile)
		{
			await _userProfileRepository.UpdateAsync(userProfile);
		}

		public async Task DeleteUserProfileAsync(int id)
		{
			await _userProfileRepository.DeleteAsync(id);
		}

		public async Task<UserProfile> LoginAsync(LoginModel model)
		{
			return await _userProfileRepository.LoginAsync(model);
		}
	}
}
