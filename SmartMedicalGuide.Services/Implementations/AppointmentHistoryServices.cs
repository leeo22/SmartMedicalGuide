using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;

namespace SmartMedicalGuide.Services.Abstracts
{
    public class AppointmentHistoryServices : IAppointmentHistoryServices
    {
        #region Fields
        private readonly IAppointmentHistoryRepository _appointmentHistoryRepository;
        #endregion

        #region Constructors
        public AppointmentHistoryServices(IAppointmentHistoryRepository appointmentHistoryRepository)
        {
            _appointmentHistoryRepository = appointmentHistoryRepository;
        }
        #endregion

        #region Handlers Functions
        public async Task<string> AddAsync(AppointmentHistory appointmentHistory)
        {
            await _appointmentHistoryRepository.AddAsync(appointmentHistory);
            return "Success";
        }

        public async Task<string> DeleteAsync(AppointmentHistory appointmentHistory)
        {
            var trans = _appointmentHistoryRepository.BeginTransaction();
            try
            {
                await _appointmentHistoryRepository.DeleteAsync(appointmentHistory);
                await trans.CommitAsync();
                return "Success";
            }
            catch
            {
                await trans.RollbackAsync();
                return "Failed";
            }
        }

        public async Task<string> EditAsync(AppointmentHistory appointmentHistory)
        {
            await _appointmentHistoryRepository.UpdateAsync(appointmentHistory);
            return "Success";
        }

        public async Task<List<AppointmentHistory>> GetByAppointmentIdAsync(int appointmentId, string appointmentType)
        {
            return await _appointmentHistoryRepository.GetTableAsTracking()
                .Where(x => x.AppointmentId == appointmentId && x.AppointmentType == appointmentType)
                .ToListAsync();
        }

        public async Task<AppointmentHistory> GetByIDAsync(int id)
        {
            var result = _appointmentHistoryRepository.GetByIdAsync()
                                            .Where(x => x.HistoryId == id)
                                            .FirstOrDefault();
            return result;
        }

        public async Task<List<AppointmentHistory>> GetListAsync()
        {
            return await _appointmentHistoryRepository.GetAppointmentHistoriesListAsync();
        }
        #endregion
    }
}