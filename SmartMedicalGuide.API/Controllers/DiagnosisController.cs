using Microsoft.AspNetCore.Mvc;
using SmartMedicalGuide.API.Base;
using SmartMedicalGuide.Data.DTOs.Requests;
using SmartMedicalGuide.Services.Abstracts;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;

namespace SmartMedicalGuide.API.Controllers
{
    [ApiController]
    public class DiagnosisController : AppControllerBase
    {
        private readonly IDiagnosisService _diagnosisService;

        public DiagnosisController(IDiagnosisService diagnosisService)
        {
            _diagnosisService = diagnosisService;
        }

        private int GetCurrentUserId()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return int.TryParse(userIdClaim, out int userId) ? userId : 0;
        }

        [SwaggerOperation(Summary = "تشخيص الأعراض باستخدام الذكاء الاصطناعي", OperationId = "DiagnoseSymptoms")]
        [HttpPost("diagnose")]
        public async Task<IActionResult> Diagnose([FromBody] DiagnoseRequestDto request)
        {
            if (string.IsNullOrWhiteSpace(request.Symptoms))
                return BadRequest(new { succeeded = false, message = "الرجاء إدخال الأعراض" });

            var userId = GetCurrentUserId();
            if (userId == 0)
                return Unauthorized(new { succeeded = false, message = "الرجاء تسجيل الدخول أولاً" });

            var result = await _diagnosisService.DiagnoseAsync(request.Symptoms, userId);
            return Ok(new { succeeded = true, data = result });
        }
    }
}
