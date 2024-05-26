using FiapHackaton.WebApp.DTO;

namespace FiapHackaton.WebApp.Contracts.Interface
{
	public interface IAuthRepository
	{
		public Task<bool> Register(UserDto user);
		public Task<bool> Login(LoginDTO user);
		public Task Logout();
	}
}
