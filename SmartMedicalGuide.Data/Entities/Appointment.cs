namespace SmartMedicalGuide.Data.Entities
{
    public class Appointment
    {
        public int AppointmentID { get; set; }
        public string AppointmentType { get; set; } // حضوري / إلكتروني
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }

        public int PatientID { get; set; }
        public Patient Patient { get; set; }

        public int? DoctorID { get; set; }
        public Doctor Doctor { get; set; }

        public int? CenterID { get; set; }
        public Center Center { get; set; }

        public Payment Payment { get; set; }
        public Prescription Prescription { get; set; }
    }

}
