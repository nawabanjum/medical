using System.ComponentModel.DataAnnotations;

namespace FiapHackaton.Web.Models
{
	public class RegisterModel
	{
		[Required]
		public string FirstName { get; set; }
		public string LastName { get; set; }
		[Required]
		public string Email { get; set; }
		[Required]
		public string Password { get; set; }
		[Required]
		public int UserTypeId { get; set; }
	}
}
