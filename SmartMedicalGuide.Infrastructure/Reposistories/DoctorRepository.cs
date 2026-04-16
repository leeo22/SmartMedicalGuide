using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Infrastructure.Context;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Reposistories
{
    public class DoctorRepository : GenericRepositoryAsync<Doctor>, IDoctorRepository
    {

        #region Fields
        private readonly DbSet<Doctor> _doctor;
        #endregion
        #region Constructors
        public DoctorRepository(MedicalGuideDbContext dbContext) : base(dbContext)
        {
            _doctor = dbContext.Set<Doctor>();
        }
        #endregion
        #region Handels Functions
        public async Task<List<Doctor>> GetDoctorsListAsync()
        {
            return await _doctor.Include(d => d.User)
                                //.ThenInclude(u => u.Role)
                                .ToListAsync();
        }
        #endregion

    }
}
