namespace SmartMedicalGuide.Core.Features.DoctorAppointments.Queries.Results
{
    public class GetDoctorAppointmentListRespones
    {

        public int AppointmentId { get; set; }
        public string DoctorName { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public string PaymentStatus { get; set; }



    }
}
