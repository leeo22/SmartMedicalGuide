using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Infrastructure.Context;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Reposistories
{
    public class AppointmentHistoryRepository : GenericRepositoryAsync<AppointmentHistory>, IAppointmentHistoryRepository
    {
        #region Fields
        private readonly DbSet<AppointmentHistory> _appointmentHistory;
        #endregion

        #region Constructors
        public AppointmentHistoryRepository(MedicalGuideDbContext dBContext) : base(dBContext)
        {
            _appointmentHistory = dBContext.Set<AppointmentHistory>();

        }

        #endregion

        #region Handels Functions

        public async Task<List<AppointmentHistory>> GetAppointmentHistoriesListAsync()
        {
            return await _appointmentHistory.ToListAsync();//Edit
        }
        #endregion


    }
}
