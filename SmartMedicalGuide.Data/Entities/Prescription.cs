namespace SmartMedicalGuide.Data.Entities
{
    public class Prescription
    {
        public int PrescriptionId { get; set; }

        public int AppointmentId { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }

        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
