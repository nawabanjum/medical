namespace FiapHackaton.WebApp.Models
{
    public class AppointmentModel
    {
        public int AppointmentID { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int ScheduleID { get; set; }

        public DateTime CreatedAt { get; set; }
        public string Comments { get; set; }
        public string Status { get; set; } // Status can be "Scheduled", "Canceled", "Completed", etc.
    }
}
