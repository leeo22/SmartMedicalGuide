using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Infrastructure.Context;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Reposistories
{
    public class PatientRepository : GenericRepositoryAsync<Patient>, IPatientRepository
    {
        #region Fields
        private readonly DbSet<Patient> _patient;
        #endregion

        #region Constructors
        public PatientRepository(MedicalGuideDbContext dBContext) : base(dBContext)
        {
            _patient = dBContext.Set<Patient>();

        }
        #endregion

        #region Handels Functions
        public async Task<List<Patient>> GetPatientsListAsync()
        {
            return await _patient.Include(d => d.User)
                                //.ThenInclude(u => u.Role)
                                .ToListAsync();
        }
        #endregion
    }
}
