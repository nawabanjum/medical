using System.ComponentModel.DataAnnotations;

namespace FiapHackaton.WebApp.DTO
{
    public class UserDto
    {
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
		
		public int UserTypeId { get; set; }

	}
}
