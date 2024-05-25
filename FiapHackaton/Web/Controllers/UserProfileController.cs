using FiapHackaton.Application.Interfaces;
using FiapHackaton.Domain.Entities;
using FiapHackaton.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FiapHackaton.Web.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserProfileController : ControllerBase
	{
		private readonly IUserProfileService _userProfileService;
		public UserProfileController(IUserProfileService userProfileService)
		{
			_userProfileService = userProfileService;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<UserProfile>>> GetAll()
		{
			var userProfiles = await _userProfileService.GetAllUserProfilesAsync();
			return Ok(userProfiles);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<UserProfile>> GetById(int id)
		{
			var userProfile = await _userProfileService.GetUserProfileByIdAsync(id);
			if (userProfile == null)
			{
				return NotFound();
			}
			return Ok(userProfile);
		}

		[HttpPost]
		[Route("register")]
		public async Task<ActionResult> Register(RegisterModel userProfile)
		{
			try
			{
				await _userProfileService.RegisterAsync(userProfile);
			}
			catch (Exception)
			{

				return BadRequest();
			}
			return Ok();
		}
		[HttpPost]
		[Route("login")]
		public async Task<ActionResult> Login(LoginModel model)
		{
			var userProfile = await _userProfileService.LoginAsync(model);
			if (userProfile == null)
			{
				return NotFound();
			}
			return Ok(userProfile);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult> Update(int id, UserProfile userProfile)
		{
			if (id != userProfile.UserId)
			{
				return BadRequest();
			}
			await _userProfileService.UpdateUserProfileAsync(userProfile);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(int id)
		{
			await _userProfileService.DeleteUserProfileAsync(id);
			return NoContent();
		}
	}
}
