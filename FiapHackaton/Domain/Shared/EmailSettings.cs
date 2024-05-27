namespace FiapHackaton.Domain.Shared
{
    public class EmailSettings
    {
        public string Key { get; set; }
        public string From { get; set; }
        public string FromName { get; set; }
        public string AdminEmail { get; set; }
        public string SendGridKey { get; set; }
    }
}
