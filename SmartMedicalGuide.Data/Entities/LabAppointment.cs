namespace SmartMedicalGuide.Data.Entities
{
    public class LabAppointment
    {
        public int LabAppointmentId { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public int LabId { get; set; }
        public Lab Lab { get; set; }

        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        public DateTime AppointmentDate { get; set; }
        public string TestType { get; set; }
        public string Status { get; set; }
        public decimal Price { get; set; }

        public Payment Payment { get; set; }
    }

}
