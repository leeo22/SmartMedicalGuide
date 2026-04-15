using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Infrastructure.Context;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Reposistories
{
    public class SpecializationRepository : GenericRepositoryAsync<Specialization>, ISpecializationRepository
    {
        #region Fields
        private readonly DbSet<Specialization> _specialization;
        #endregion

        #region Constructors
        public SpecializationRepository(MedicalGuideDbContext dBContext) : base(dBContext)
        {
            _specialization = dBContext.Set<Specialization>();

        }

        #endregion

        #region Handels Functions

        public async Task<List<Specialization>> GetSpecializationsListAsync()
        {
            return await _specialization.ToListAsync();//Edit
        }
        #endregion


    }
}
