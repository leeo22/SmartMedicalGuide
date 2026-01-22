namespace SmartMedicalGuide.Data.Entities
{
    public class Prescription
    {
        public int PrescriptionID { get; set; }
        public string MedicationDetails { get; set; }
        public string Notes { get; set; }
        public DateTime IssuedAt { get; set; }

        public int AppointmentID { get; set; }
        public Appointment Appointment { get; set; }
    }


}
