namespace SmartMedicalGuide.Data.DTOs.Result
{
    public class AiDiagnosisResult
    {
        public string Diagnosis { get; set; }
        public string Cause { get; set; }
        public string Specialty { get; set; }
        public string SpecialtyName { get; set; }
        public double Confidence { get; set; }
        public List<string> Recommendations { get; set; }
    }
}
