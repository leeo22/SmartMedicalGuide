using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Services.Abstracts
{
    public interface IVerificationRequestServices
    {
        public Task<List<VerificationRequest>> GetListAsync();
        public Task<VerificationRequest> GetByIDAsync(int id);
        public Task<string> AddAsync(VerificationRequest verificationRequest);
        public Task<string> EditAsync(VerificationRequest verificationRequest);
        public Task<string> DeleteAsync(VerificationRequest verificationRequest);
        public Task<List<VerificationRequest>> GetByUserIdAsync(int userId);
        public Task<List<VerificationRequest>> GetByStatusAsync(string status);
    }
}