using System.ComponentModel.DataAnnotations;

namespace SmartMedicalGuide.Data.Entities
{
    public class SymptomDiagnosis
    {
        [Key]
        public int DiagnosisId { get; set; }
        public int SymptomId { get; set; }
        public Symptom Symptom { get; set; }
        public string Specialization { get; set; }
    }

}
