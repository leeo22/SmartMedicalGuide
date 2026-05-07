using SmartMedicalGuide.Data.DTOs;
using SmartMedicalGuide.Data.DTOs.Respones;
using SmartMedicalGuide.Data.DTOs.Result;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Context;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Services.Implementations
{
    public class DiagnosisService : IDiagnosisService
    {
        private readonly IDr7AiService _dr7AiService;
        private readonly IDoctorServices _doctorServices;
        private readonly ISpecializationServices _specializationServices;
        private readonly MedicalGuideDbContext _dbContext;

        public DiagnosisService(
            IDr7AiService dr7AiService,
            IDoctorServices doctorServices,
            ISpecializationServices specializationServices,
            MedicalGuideDbContext dbContext)
        {
            _dr7AiService = dr7AiService;
            _doctorServices = doctorServices;
            _specializationServices = specializationServices;
            _dbContext = dbContext;
        }

        public async Task<DiagnoseResponseDto> DiagnoseAsync(string symptoms, int userId)
        {
            // 1. الحصول على التشخيص من AI
            var aiResult = await _dr7AiService.GetDiagnosisAsync(symptoms);

            // 2. البحث عن التخصص في قاعدة البيانات
            var specialization = await _specializationServices.GetByNameAsync(aiResult.SpecialtyName);
            List<DoctorDto> doctors = new List<DoctorDto>();

            if (specialization != null)
            {
                var allDoctors = await _doctorServices.GetBySpecializationIdAsync(specialization.SpecializationId);
                doctors = allDoctors
                    .Where(d => d.IsAvailableForBooking && d.VerificationStatus == "Verified")
                    .Select(d => new DoctorDto
                    {
                        DoctorId = d.DoctorId,
                        DoctorName = d.User?.FullName ?? "طبيب",
                        SpecializationName = specialization.Name,
                        ProfileImageUrl = d.ProfileImageUrl,
                        ConsultationPrice = d.ConsultationPrice,
                        AverageRating = d.Reviews != null && d.Reviews.Any() ? d.Reviews.Average(r => r.Rating) : 0,
                        ReviewsCount = d.Reviews?.Count ?? 0,
                        IsAvailableForBooking = d.IsAvailableForBooking
                    })
                    .OrderByDescending(d => d.AverageRating)
                    .ToList();
            }
            else
            {
                var allDoctors = await _doctorServices.GetListAsync();
                doctors = allDoctors
                    .Where(d => d.IsAvailableForBooking && d.VerificationStatus == "Verified")
                    .Take(10)
                    .Select(d => new DoctorDto
                    {
                        DoctorId = d.DoctorId,
                        DoctorName = d.User?.FullName ?? "طبيب",
                        SpecializationName = d.Specialization?.Name ?? "طبيب عام",
                        ProfileImageUrl = d.ProfileImageUrl,
                        ConsultationPrice = d.ConsultationPrice,
                        AverageRating = d.Reviews != null && d.Reviews.Any() ? d.Reviews.Average(r => r.Rating) : 0,
                        ReviewsCount = d.Reviews?.Count ?? 0,
                        IsAvailableForBooking = d.IsAvailableForBooking
                    })
                    .OrderByDescending(d => d.AverageRating)
                    .ToList();
            }

            // 3. حفظ سجل التشخيص
            var diagnosisHistory = new DiagnosisHistory
            {
                UserId = userId,
                Symptoms = symptoms,
                AiDiagnosis = aiResult.Diagnosis,
                AiCause = aiResult.Cause,
                SpecialtyName = aiResult.SpecialtyName,
                Confidence = aiResult.Confidence,
                ResponseTimeMs = aiResult.ResponseTimeMs,
                IsFromFallback = aiResult.IsFromFallback,
                ErrorMessage = aiResult.ErrorMessage
            };
            await _dbContext.DiagnosisHistories.AddAsync(diagnosisHistory);
            await _dbContext.SaveChangesAsync();

            return new DiagnoseResponseDto
            {
                Diagnosis = new AiDiagnosisResult
                {
                    Diagnosis = aiResult.Diagnosis,
                    Cause = aiResult.Cause,
                    Specialty = aiResult.Specialty,
                    SpecialtyName = aiResult.SpecialtyName,
                    Confidence = aiResult.Confidence,
                    Recommendations = aiResult.Recommendations
                },
                RecommendedDoctors = doctors
            };
        }
    }
}