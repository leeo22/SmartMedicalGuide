using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SmartMedicalGuide.Services.Abstracts;
using System.Text;
using System.Text.Json;

namespace SmartMedicalGuide.Services.Implementations
{
    public class Dr7AiService : IDr7AiService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly ILogger<Dr7AiService> _logger;
        private readonly IMemoryCache _cache;

        public Dr7AiService(HttpClient httpClient, IConfiguration configuration, ILogger<Dr7AiService> logger, IMemoryCache cache)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _logger = logger;
            _cache = cache;
        }

        public async Task<AiDiagnosisResponse> GetDiagnosisAsync(string symptoms)
        {
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            var normalizedSymptoms = symptoms.Trim().ToLower();

            // التحقق من Cache
            if (_cache.TryGetValue(normalizedSymptoms, out AiDiagnosisResponse cachedResult))
            {
                stopwatch.Stop();
                cachedResult.ResponseTimeMs = (int)stopwatch.ElapsedMilliseconds;
                cachedResult.IsFromFallback = false;
                return cachedResult;
            }

            // محاولة الاتصال مع Retry (3 محاولات)
            for (int attempt = 1; attempt <= 3; attempt++)
            {
                try
                {
                    var result = await CallDr7AiAsync(symptoms);
                    stopwatch.Stop();
                    result.ResponseTimeMs = (int)stopwatch.ElapsedMilliseconds;
                    result.IsFromFallback = false;

                    if (result.Confidence > 70)
                    {
                        _cache.Set(normalizedSymptoms, result, TimeSpan.FromHours(24));
                    }
                    return result;
                }
                catch (HttpRequestException ex) when (attempt < 3)
                {
                    _logger.LogWarning($"Attempt {attempt} failed: {ex.Message}");
                    await Task.Delay(1000 * attempt);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error calling dr7.ai API");
                    break;
                }
            }

            stopwatch.Stop();
            return GetFallbackResponse(symptoms, (int)stopwatch.ElapsedMilliseconds);
        }

        //private async Task<AiDiagnosisResponse> CallDr7AiAsync(string symptoms)
        //{
        //    var apiKey = _configuration["Dr7Ai:ApiKey"];
        //    var baseUrl = _configuration["Dr7Ai:BaseUrl"];

        //    _httpClient.DefaultRequestHeaders.Authorization =
        //        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);

        //    var requestBody = new
        //    {
        //        model = "medgemma-4b-it",  // ✅ تمت الإضافة
        //        messages = new[]
        //        {
        //    new { role = "system", content = GetSystemPrompt() },
        //    new { role = "user", content = $"الأعراض: {symptoms}" }
        //},
        //        temperature = 0.3,
        //        max_tokens = 500
        //    };

        //    var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");
        //    var response = await _httpClient.PostAsync(baseUrl, content);

        //    if (!response.IsSuccessStatusCode)
        //    {
        //        var errorContent = await response.Content.ReadAsStringAsync();
        //        throw new HttpRequestException($"API Error {response.StatusCode}: {errorContent}");
        //    }

        //    var jsonResponse = await response.Content.ReadAsStringAsync();
        //    return ParseDr7AiResponse(jsonResponse);
        //}
        private async Task<AiDiagnosisResponse> CallDr7AiAsync(string symptoms)
        {
            var apiKey = _configuration["Dr7Ai:ApiKey"];
            var baseUrl = _configuration["Dr7Ai:BaseUrl"];

            _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);

            var requestBody = new
            {
                model = "biogpt",  // ✅ جرب هذا أولاً
                messages = new[]
      {
        new { role = "system", content = GetSystemPrompt() },
        new { role = "user", content = $"الأعراض: {symptoms}" }
    },
                temperature = 0.3,
                max_tokens = 500
            };

            var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(baseUrl, content);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"API Error {response.StatusCode}: {errorContent}");
            }

            var jsonResponse = await response.Content.ReadAsStringAsync();
            return ParseDr7AiResponse(jsonResponse);
        }

        private string GetSystemPrompt()
        {
            return @"أنت مساعد طبي متخصص في التشخيص الأولي. 
            بناءً على الأعراض، قدم:
            1. التشخيص المحتمل
            2. السبب المحتمل
            3. التخصص الطبي المطلوب
            4. نسبة الثقة (0-100)
            5. توصيات عامة
            أعد البيانات بتنسيق JSON فقط";
        }

        private AiDiagnosisResponse ParseDr7AiResponse(string jsonResponse)
        {
            try
            {
                using var doc = JsonDocument.Parse(jsonResponse);
                var content = doc.RootElement.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString();
                return JsonSerializer.Deserialize<AiDiagnosisResponse>(content);
            }
            catch
            {
                throw new Exception("Failed to parse AI response");
            }
        }

        private AiDiagnosisResponse GetFallbackResponse(string symptoms, int responseTimeMs)
        {
            return new AiDiagnosisResponse
            {
                Diagnosis = "تحليل مؤقت",
                Cause = "تعذر الاتصال بخدمة التشخيص الذكي",
                Specialty = "عام",
                SpecialtyName = "طب عام",
                Confidence = 0,
                Recommendations = new List<string> { "يرجى استشارة طبيب عام" },
                IsFromFallback = true,
                ErrorMessage = "خدمة التشخيص غير متاحة حالياً",
                ResponseTimeMs = responseTimeMs
            };
        }
    }
}