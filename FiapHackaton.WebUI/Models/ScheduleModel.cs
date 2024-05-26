
namespace FiapHackaton.WebUI.Models
{
    public class ScheduleModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int UserTypeId { get; set; }
       public List<Schedule> Schedules { get; set; }
    }
}
