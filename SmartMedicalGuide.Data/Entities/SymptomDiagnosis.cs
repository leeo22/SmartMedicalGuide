namespace SmartMedicalGuide.Data.Entities
{
    public class SymptomDiagnosis
    {
        public int DiagnosisId { get; set; }
        public int SymptomId { get; set; }
        public Symptom Symptom { get; set; }
        public string Specialization { get; set; }
    }

}
