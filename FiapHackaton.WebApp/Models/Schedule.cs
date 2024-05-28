namespace FiapHackaton.WebApp.Models
{
	public class Schedule
	{
		public int ScheduleID { get; set; }
		public int DoctorID { get; set; }
		public string DayOfWeek { get; set; }
		public string StartTime { get; set; }
		public string EndTime { get; set; }
		public string DocComments { get; set; }
		public bool Deleted { get; set; }
	}
}
