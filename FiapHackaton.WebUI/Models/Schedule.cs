namespace FiapHackaton.WebUI.Models
{
	public class Schedule
	{
		public int ScheduleID { get; set; }
		public int DoctorID { get; set; }
		public string DayOfWeek { get; set; }
		public TimeSpan StartTime { get; set; }
		public TimeSpan EndTime { get; set; }
		public string DocComments { get; set; }
	}
}
