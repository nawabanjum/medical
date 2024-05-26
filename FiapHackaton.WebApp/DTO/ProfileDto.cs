namespace FiapHackaton.WebApp.DTO
{
    public class ProfileDto
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; }
        public string? Description { get; set; }
        public string? PhoneNumber { get; set; }
        public int UserTypeId { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
