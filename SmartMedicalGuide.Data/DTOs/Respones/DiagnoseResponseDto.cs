using SmartMedicalGuide.Data.DTOs.Result;

namespace SmartMedicalGuide.Data.DTOs.Respones
{
    public class DiagnoseResponseDto
    {
        public AiDiagnosisResult Diagnosis { get; set; }
        public List<DoctorDto> RecommendedDoctors { get; set; }
    }

}
