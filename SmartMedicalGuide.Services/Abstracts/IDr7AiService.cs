namespace SmartMedicalGuide.Services.Abstracts
{
    public interface IDr7AiService
    {
        Task<AiDiagnosisResponse> GetDiagnosisAsync(string symptoms);
    }

    public class AiDiagnosisResponse
    {
        public string Diagnosis { get; set; } = "تحليل مؤقت";
        public string Cause { get; set; } = "تعذر الاتصال بخدمة التشخيص";
        public string Specialty { get; set; } = "عام";
        public string SpecialtyName { get; set; } = "طب عام";
        public double Confidence { get; set; }
        public List<string> Recommendations { get; set; } = new();
        public bool IsFromFallback { get; set; }
        public string? ErrorMessage { get; set; }
        public int ResponseTimeMs { get; set; }
    }
}