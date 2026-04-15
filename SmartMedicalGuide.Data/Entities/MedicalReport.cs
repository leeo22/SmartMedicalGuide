using System.ComponentModel.DataAnnotations;

namespace SmartMedicalGuide.Data.Entities
{
    public class MedicalReport
    {
        [Key]
        public int ReportId { get; set; }

        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int LabId { get; set; }

        public string? FilePath { get; set; }
        public string? ReportType { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

}
