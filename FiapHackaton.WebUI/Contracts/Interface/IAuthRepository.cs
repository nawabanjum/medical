using FiapHackaton.WebUI.DTO;

namespace FiapHackaton.WebUI.Contracts.Interface
{
	public interface IAuthRepository
	{
		public Task<bool> Register(UserDto user);
		public Task<bool> Login(LoginDTO user);
		public Task Logout();
	}
}
