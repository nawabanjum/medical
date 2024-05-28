using System.ComponentModel.DataAnnotations;

namespace FiapHackaton.Web.Models
{
    public class ForgotPasswordModel
    {
        [Required]
        public string Email { get; set; }
    }
}
