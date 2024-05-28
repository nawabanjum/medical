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
        [HttpGet]
        [Route("doctors")]
        public async Task<ActionResult<IEnumerable<ScheduleModel>>> GetAllDoctors()
        {
            var userProfiles = await _userProfileService.GetAllDoctorsAsync();
            return Ok(userProfiles);
        }
        [HttpGet]
        [Route("patients")]
        public async Task<ActionResult<IEnumerable<UserProfile>>> GetAllPatients()
        {
            var userProfiles = await _userProfileService.GetAllPatientsAsync();
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
        public async Task<ActionResult> Register([FromBody] RegisterModel userProfile)
        {
            try
            {
                await _userProfileService.RegisterAsync(userProfile);
            }
            catch (Exception ex)
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

        [HttpPost]
        [Route("Update")]
        public async Task<ActionResult> Update(UserProfile userProfile)
        {
            try
            {

                if (userProfile.UserId <= 0)
                {
                    return BadRequest();
                }
                await _userProfileService.UpdateUserProfileAsync(userProfile);
            }
            catch (Exception ex)
            {

                throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _userProfileService.DeleteUserProfileAsync(id);
            return NoContent();
        }

        [HttpPost]
        [Route("forgot-password")]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordModel model)
        {
            var userProfile = await _userProfileService.GetByEmail(model.Email);
            if (userProfile == null)
            {
                return NotFound();
            }
            return Ok(userProfile);
        }
        //[HttpPut]
        //[Route("resetPassword")]
        //public async Task<ApiResponse> ResetPassword([FromBody] ResetPasswordModel model)
        //{
        //    await _authService.ResetPasswordAsync(model);

        //    return new ApiResponse(ContstantMessages.PasswordResetSuccess);
        //}
    }
}
