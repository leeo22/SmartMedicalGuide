namespace SmartMedicalGuide.Core.Features.AppointmentHistories.Queries.Results
{
    public class GetAppointmentHistoryListResponse
    {
        public int HistoryId { get; set; }
        public int AppointmentId { get; set; }
        public string AppointmentType { get; set; }
        public string Status { get; set; }
        public DateTime ChangedAt { get; set; }
    }
}