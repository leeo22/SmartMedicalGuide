using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Services.Implementations
{
    public class SpecializationServices : ISpecializationServices
    {
        #region Fields
        private readonly ISpecializationRepository _specializationRepository;
        #endregion
        #region Constructors
        public SpecializationServices(ISpecializationRepository specializationRepository)
        {
            _specializationRepository = specializationRepository;
        }


        #endregion
        #region Handels Functions


        public async Task<string> AddAsync(Specialization specialization)
        {
            await _specializationRepository.AddAsync(specialization);
            return "Success";
        }


        public async Task<string> DeleteAsync(Specialization specialization)
        {
            var trans = _specializationRepository.BeginTransaction();
            try
            {
                await _specializationRepository.DeleteAsync(specialization);
                await trans.CommitAsync();
                return "Success";
            }
            catch
            {
                await trans.RollbackAsync();
                return "Falied";
            }
        }

        public async Task<string> EditAsync(Specialization specialization)
        {
            await _specializationRepository.UpdateAsync(specialization);
            return "Success";
        }

        public async Task<List<Specialization>> GetListAsync()
        {
            return await _specializationRepository.GetSpecializationsListAsync();
        }

        public async Task<Specialization> GetByIDAsync(int id)
        {
            var report = _specializationRepository.GetByIdAsync()
                                            .Where(x => x.SpecializationId.Equals(id))
                                            .FirstOrDefault();
            return report;
        }



        #endregion
    }
}

