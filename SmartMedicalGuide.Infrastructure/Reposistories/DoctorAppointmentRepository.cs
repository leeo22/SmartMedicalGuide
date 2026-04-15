using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Infrastructure.Context;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Reposistories
{
    public class DoctorAppointmentRepository : GenericRepositoryAsync<DoctorAppointment>, IDoctorAppointmentRepository
    {
        #region Fields
        private readonly DbSet<DoctorAppointment> _doctorAppointment;
        #endregion
        #region Constructors
        public DoctorAppointmentRepository(MedicalGuideDbContext dbContext) : base(dbContext)
        {
            _doctorAppointment = dbContext.Set<DoctorAppointment>();
        }
        #endregion
        #region Handels Functions
        public async Task<List<DoctorAppointment>> GetDoctorAppointmentsListAsync()
        {
            return await _doctorAppointment
                    .Include(a => a.Doctor)
                    .ThenInclude(d => d.User)
                    .Include(a => a.Patient)
                    .ThenInclude(p => p.User)

                .ToListAsync();
        }
        #endregion

    }
}
