using SmartMedicalGuide.Data.DTOs.Respones;

namespace SmartMedicalGuide.Services.Abstracts
{
    public interface IDiagnosisService
    {
        Task<DiagnoseResponseDto> DiagnoseAsync(string symptoms, int userId);
    }
}