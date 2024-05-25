﻿namespace FiapHackaton.Web.Models
{
    public class AppointmentModel
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; } // Status can be "Scheduled", "Canceled", "Completed", etc.
    }
}
