using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiapHackaton.Domain.Entities
{
    [Table("Schedule")]
    public class Schedule
	{
        [Key]
        public int ScheduleID { get; set; }
		public int DoctorID { get; set; }
        public string DayOfWeek { get; set; }
		public string StartTime { get; set; }
		public string EndTime { get; set; }
		public string DocComments { get; set; }
        public bool Deleted { get; set; }
    }
}
