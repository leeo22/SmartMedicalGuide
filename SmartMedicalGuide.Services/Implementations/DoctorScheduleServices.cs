using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Services.Implementations
{
    public class DoctorScheduleServices : IDoctorScheduleServices
    {
        #region Fields
        private readonly IDoctorScheduleRepository _scheduleRepository;
        #endregion

        #region Constructors
        public DoctorScheduleServices(IDoctorScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }
        #endregion

        #region Basic CRUD Handlers
        public async Task<List<DoctorSchedule>> GetListAsync()
        {
            try
            {
                return await _scheduleRepository.GetAllSchedulesWithIncludesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting schedules list: {ex.Message}", ex);
            }
        }

        public async Task<DoctorSchedule?> GetByIDAsync(int id)
        {
            try
            {
                return await _scheduleRepository.GetScheduleByIdWithIncludesAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting schedule by ID {id}: {ex.Message}", ex);
            }
        }

        public async Task<string> AddAsync(DoctorSchedule schedule)
        {
            try
            {
                // Check if schedule already exists for this doctor and day
                var existing = await _scheduleRepository.GetActiveScheduleByDoctorAndDayAsync(schedule.DoctorId, schedule.DayOfWeek);
                if (existing != null)
                    return "Schedule already exists for this doctor on this day";

                schedule.IsActive = true;
                schedule.IsDeleted = false;

                await _scheduleRepository.AddAsync(schedule);
                return "Success";
            }
            catch (Exception ex)
            {
                return $"Failed to add schedule: {ex.Message}";
            }
        }

        public async Task<string> EditAsync(DoctorSchedule schedule)
        {
            try
            {
                var existing = await _scheduleRepository.GetTableAsTracking()
                    .FirstOrDefaultAsync(x => x.ScheduleId == schedule.ScheduleId && !x.IsDeleted);

                if (existing == null)
                    return "Schedule not found";

                existing.StartTime = schedule.StartTime;
                existing.EndTime = schedule.EndTime;
                existing.BreakStartTime = schedule.BreakStartTime;
                existing.BreakEndTime = schedule.BreakEndTime;
                existing.MaxAppointmentsPerSlot = schedule.MaxAppointmentsPerSlot;
                existing.SlotDuration = schedule.SlotDuration;
                existing.IsActive = schedule.IsActive;

                await _scheduleRepository.UpdateAsync(existing);
                return "Success";
            }
            catch (Exception ex)
            {
                return $"Failed to edit schedule: {ex.Message}";
            }
        }

        public async Task<string> DeleteAsync(DoctorSchedule schedule)
        {
            try
            {
                schedule.IsDeleted = true;
                await _scheduleRepository.UpdateAsync(schedule);
                return "Success";
            }
            catch (Exception ex)
            {
                return $"Failed to delete schedule: {ex.Message}";
            }
        }
        #endregion

        #region Additional Important Functions
        public async Task<List<DoctorSchedule>> GetByDoctorIdAsync(int doctorId)
        {
            try
            {
                return await _scheduleRepository.GetByDoctorIdAsync(doctorId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting schedules for doctor {doctorId}: {ex.Message}", ex);
            }
        }

        public async Task<List<DoctorSchedule>> GetByDayOfWeekAsync(string dayOfWeek)
        {
            try
            {
                return await _scheduleRepository.GetByDayOfWeekAsync(dayOfWeek);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting schedules for day {dayOfWeek}: {ex.Message}", ex);
            }
        }

        public async Task<DoctorSchedule?> GetDoctorScheduleByDayAsync(int doctorId, string dayOfWeek)
        {
            try
            {
                return await _scheduleRepository.GetDoctorScheduleByDayAsync(doctorId, dayOfWeek);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting schedule for doctor {doctorId} on {dayOfWeek}: {ex.Message}", ex);
            }
        }

        public async Task<List<TimeSpan>> GetDoctorAvailableSlotsAsync(int doctorId, DateTime date)
        {
            try
            {
                return await _scheduleRepository.GetDoctorAvailableSlotsAsync(doctorId, date);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting available slots for doctor {doctorId} on {date:yyyy-MM-dd}: {ex.Message}", ex);
            }
        }

        public async Task<bool> CheckDoctorAvailableAsync(int doctorId, DateTime dateTime)
        {
            try
            {
                return await _scheduleRepository.CheckDoctorAvailableAsync(doctorId, dateTime);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error checking availability for doctor {doctorId} at {dateTime}: {ex.Message}", ex);
            }
        }
        #endregion
    }
}