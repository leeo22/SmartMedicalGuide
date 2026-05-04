namespace SmartMedicalGuide.Core.Features.Doctors.Queries.Results
{
    public class DoctorStatisticsResponse
    {
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string? Gender { get; set; }
        public int? YearsOfExperience { get; set; }
        public int TotalAppointments { get; set; }
        public int CompletedAppointments { get; set; }
        public int CancelledAppointments { get; set; }
        public int PendingAppointments { get; set; }
        public decimal TotalRevenue { get; set; }
        public double AverageRating { get; set; }
        public int TotalReviews { get; set; }
        public int TotalPrescriptions { get; set; }
    }
}