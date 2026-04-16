namespace SmartMedicalGuide.Core.Features.PrescriptionItems.Queries.Results
{
    public class GetPrescriptionItemListResponse
    {
        public int ItemId { get; set; }
        public int PrescriptionId { get; set; }
        public string MedicineName { get; set; }
        public string Dosage { get; set; }
        public string Duration { get; set; }
    }
}