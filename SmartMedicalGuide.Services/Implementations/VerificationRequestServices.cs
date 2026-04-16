using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;

namespace SmartMedicalGuide.Services.Abstracts
{
    public class VerificationRequestServices : IVerificationRequestServices
    {
        #region Fields
        private readonly IVerificationRequestRepository _verificationRequestRepository;
        #endregion

        #region Constructors
        public VerificationRequestServices(IVerificationRequestRepository verificationRequestRepository)
        {
            _verificationRequestRepository = verificationRequestRepository;
        }
        #endregion

        #region Handlers Functions
        public async Task<string> AddAsync(VerificationRequest verificationRequest)
        {
            await _verificationRequestRepository.AddAsync(verificationRequest);
            return "Success";
        }

        public async Task<string> DeleteAsync(VerificationRequest verificationRequest)
        {
            var trans = _verificationRequestRepository.BeginTransaction();
            try
            {
                await _verificationRequestRepository.DeleteAsync(verificationRequest);
                await trans.CommitAsync();
                return "Success";
            }
            catch
            {
                await trans.RollbackAsync();
                return "Failed";
            }
        }

        public async Task<string> EditAsync(VerificationRequest verificationRequest)
        {
            await _verificationRequestRepository.UpdateAsync(verificationRequest);
            return "Success";
        }

        public async Task<VerificationRequest> GetByIDAsync(int id)
        {
            var result = _verificationRequestRepository.GetByIdAsync()
                                            .Where(x => x.RequestId == id)
                                            .FirstOrDefault();
            return result;
        }

        public async Task<List<VerificationRequest>> GetByStatusAsync(string status)
        {
            return await _verificationRequestRepository.GetTableAsTracking()
                .Where(x => x.Status == status)
                .ToListAsync();
        }

        public async Task<List<VerificationRequest>> GetByUserIdAsync(int userId)
        {
            return await _verificationRequestRepository.GetTableAsTracking()
                .Where(x => x.UserId == userId)
                .ToListAsync();
        }

        public async Task<List<VerificationRequest>> GetListAsync()
        {
            return await _verificationRequestRepository.GetTableAsTracking().ToListAsync();
        }
        #endregion
    }
}