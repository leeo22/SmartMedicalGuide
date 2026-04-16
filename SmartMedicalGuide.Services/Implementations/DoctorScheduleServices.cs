using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Services.Implementations
{
    public class DoctorScheduleServices : IDoctorScheduleServices
    {
        #region Fields
        private readonly IDoctorScheduleRepository _doctorScheduleRepository;
        #endregion

        #region Constructors
        public DoctorScheduleServices(IDoctorScheduleRepository doctorScheduleRepository)
        {
            _doctorScheduleRepository = doctorScheduleRepository;
        }
        #endregion

        #region Handlers Functions
        public async Task<string> AddAsync(DoctorSchedule doctorSchedule)
        {
            await _doctorScheduleRepository.AddAsync(doctorSchedule);
            return "Success";
        }

        public async Task<string> DeleteAsync(DoctorSchedule doctorSchedule)
        {
            var trans = _doctorScheduleRepository.BeginTransaction();
            try
            {
                await _doctorScheduleRepository.DeleteAsync(doctorSchedule);
                await trans.CommitAsync();
                return "Success";
            }
            catch
            {
                await trans.RollbackAsync();
                return "Failed";
            }
        }

        public async Task<string> EditAsync(DoctorSchedule doctorSchedule)
        {
            await _doctorScheduleRepository.UpdateAsync(doctorSchedule);
            return "Success";
        }

        public async Task<List<DoctorSchedule>> GetByDoctorIdAsync(int doctorId)
        {
            return await _doctorScheduleRepository.GetTableAsTracking()
                .Where(x => x.DoctorId == doctorId)
                .ToListAsync();
        }

        public async Task<List<DoctorSchedule>> GetByDoctorIdAndDayAsync(int doctorId, string dayOfWeek)
        {
            return await _doctorScheduleRepository.GetTableAsTracking()
                .Where(x => x.DoctorId == doctorId && x.DayOfWeek == dayOfWeek)
                .ToListAsync();
        }

        public async Task<DoctorSchedule> GetByIDAsync(int id)
        {
            var result = _doctorScheduleRepository.GetByIdAsync()
                                            .Where(x => x.ScheduleId == id)
                                            .FirstOrDefault();
            return result;
        }

        public async Task<List<DoctorSchedule>> GetListAsync()
        {
            return await _doctorScheduleRepository.GetTableAsTracking().ToListAsync();
        }

        public async Task<bool> IsTimeSlotAvailableAsync(int doctorId, string dayOfWeek, DateTime startTime, DateTime endTime)
        {
            var existingSchedules = await _doctorScheduleRepository.GetTableAsTracking()
                .Where(x => x.DoctorId == doctorId && x.DayOfWeek == dayOfWeek)
                .ToListAsync();

            foreach (var schedule in existingSchedules)
            {
                // تحقق إذا كان هناك تداخل في المواعيد
                if (startTime < schedule.EndTime && endTime > schedule.StartTime)
                {
                    return false; // هناك تداخل
                }
            }
            return true; // الوقت متاح
        }
        #endregion
    }
}