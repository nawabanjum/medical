using System.ComponentModel.DataAnnotations;

namespace FiapHackaton.WebApp.DTO
{
    public class LoginDTO
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
