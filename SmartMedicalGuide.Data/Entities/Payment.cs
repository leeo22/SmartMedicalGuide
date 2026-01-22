namespace SmartMedicalGuide.Data.Entities
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }
        public DateTime PaidAt { get; set; }

        public int AppointmentID { get; set; }
        public Appointment Appointment { get; set; }
    }

}
