using System.ComponentModel.DataAnnotations;

namespace FiapHackaton.WebApp.DTO
{
    public class ForgotPasswordDTO
    {
        [Required]
        public string Email { get; set; }
    }
    public class ResetPasswordDTO
    {
        [Required]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "The password must be at least 6 characters long.")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
