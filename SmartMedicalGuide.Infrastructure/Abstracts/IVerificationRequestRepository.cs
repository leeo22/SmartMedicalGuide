using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Abstracts
{
    public interface IVerificationRequestRepository : IGenericRepositoryAsync<VerificationRequest>
    {
        //public Task<List<VerificationRequest>> GetVerificationRequestsListAsync();
    }
}
