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
                .Include(a => a.Doctor)       // يجيب بيانات الدكتور
                    .ThenInclude(d => d.User) // يجيب بيانات اليوزر للدكتور (الاسم، الرول...)
                .Include(a => a.Patient)      // يجيب بيانات المريض
                    .ThenInclude(p => p.User) // يجيب بيانات اليوزر للمريض
                .Include(a => a.Payment)      // يجيب بيانات الدفع إذا موجود
                .ToListAsync();
        }
        #endregion

    }
}
