using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Infrastructure.Context;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Repositories
{
    public class DoctorScheduleRepository : GenericRepositoryAsync<DoctorSchedule>, IDoctorScheduleRepository
    {
        #region Fields
        private readonly DbSet<DoctorSchedule> _schedules;
        private readonly IDoctorAppointmentRepository _appointmentRepository;
        #endregion

        #region Constructors
        public DoctorScheduleRepository(MedicalGuideDbContext dbContext, IDoctorAppointmentRepository appointmentRepository) : base(dbContext)
        {
            _schedules = dbContext.Set<DoctorSchedule>();
            _appointmentRepository = appointmentRepository;
        }
        #endregion

        #region Basic Handlers
        public async Task<DoctorSchedule?> GetScheduleByIdWithIncludesAsync(int id)
        {
            return await _schedules
                .Include(x => x.Doctor)
                    .ThenInclude(d => d.User)
                .Where(x => !x.IsDeleted && x.IsActive)
                .FirstOrDefaultAsync(x => x.ScheduleId == id);
        }

        public async Task<List<DoctorSchedule>> GetAllSchedulesWithIncludesAsync()
        {
            return await _schedules
                .Include(x => x.Doctor)
                    .ThenInclude(d => d.User)
                .Where(x => !x.IsDeleted && x.IsActive)
                .OrderBy(x => x.DoctorId)
                .ThenBy(x => x.DayOfWeek)
                .ToListAsync();
        }
        #endregion

        #region Additional Handlers
        public async Task<List<DoctorSchedule>> GetByDoctorIdAsync(int doctorId)
        {
            return await _schedules
                .Include(x => x.Doctor)
                    .ThenInclude(d => d.User)
                .Where(x => x.DoctorId == doctorId && !x.IsDeleted && x.IsActive)
                .OrderBy(x => x.DayOfWeek)
                .ToListAsync();
        }

        public async Task<List<DoctorSchedule>> GetByDayOfWeekAsync(string dayOfWeek)
        {
            return await _schedules
                .Include(x => x.Doctor)
                    .ThenInclude(d => d.User)
                .Where(x => x.DayOfWeek == dayOfWeek && !x.IsDeleted && x.IsActive)
                .ToListAsync();
        }

        public async Task<DoctorSchedule?> GetDoctorScheduleByDayAsync(int doctorId, string dayOfWeek)
        {
            return await _schedules
                .Include(x => x.Doctor)
                    .ThenInclude(d => d.User)
                .Where(x => x.DoctorId == doctorId && x.DayOfWeek == dayOfWeek && !x.IsDeleted && x.IsActive)
                .FirstOrDefaultAsync();
        }

        public async Task<List<TimeSpan>> GetDoctorAvailableSlotsAsync(int doctorId, DateTime date)
        {
            var dayOfWeek = date.DayOfWeek.ToString();
            var schedule = await GetDoctorScheduleByDayAsync(doctorId, dayOfWeek);

            if (schedule == null)
                return new List<TimeSpan>();

            var appointments = await _appointmentRepository.GetTableAsTracking()
                .Where(x => x.DoctorId == doctorId
                    && x.AppointmentDate.HasValue
                    && x.AppointmentDate.Value.Date == date.Date
                    && x.Status != "Cancelled"
                    && !x.IsDeleted)
                .Select(x => x.AppointmentDate.Value.TimeOfDay)
                .ToListAsync();

            var availableSlots = new List<TimeSpan>();
            var currentSlot = schedule.StartTime.Value.TimeOfDay;
            var endTime = schedule.EndTime.Value.TimeOfDay;
            var slotDuration = TimeSpan.FromMinutes(schedule.SlotDuration);

            while (currentSlot < endTime)
            {
                var slotEnd = currentSlot + slotDuration;

                // Check if slot is within break time
                var isBreakTime = schedule.BreakStartTime.HasValue && schedule.BreakEndTime.HasValue
                    && currentSlot >= schedule.BreakStartTime.Value && currentSlot < schedule.BreakEndTime.Value;

                if (!isBreakTime && !appointments.Any(a => a >= currentSlot && a < slotEnd))
                {
                    var appointmentsInSlot = appointments.Count(a => a >= currentSlot && a < slotEnd);
                    if (appointmentsInSlot < schedule.MaxAppointmentsPerSlot)
                    {
                        availableSlots.Add(currentSlot);
                    }
                }
                currentSlot = slotEnd;
            }

            return availableSlots;
        }

        public async Task<bool> CheckDoctorAvailableAsync(int doctorId, DateTime dateTime)
        {
            var dayOfWeek = dateTime.DayOfWeek.ToString();
            var schedule = await GetDoctorScheduleByDayAsync(doctorId, dayOfWeek);

            if (schedule == null)
                return false;

            var timeOfDay = dateTime.TimeOfDay;

            // Check if within working hours
            if (timeOfDay < schedule.StartTime.Value.TimeOfDay || timeOfDay >= schedule.EndTime.Value.TimeOfDay)
                return false;

            // Check if within break time
            if (schedule.BreakStartTime.HasValue && schedule.BreakEndTime.HasValue)
            {
                if (timeOfDay >= schedule.BreakStartTime.Value && timeOfDay < schedule.BreakEndTime.Value)
                    return false;
            }

            // Check if appointment already exists
            var existingAppointment = await _appointmentRepository.GetTableAsTracking()
                .AnyAsync(x => x.DoctorId == doctorId
                    && x.AppointmentDate == dateTime
                    && x.Status != "Cancelled"
                    && !x.IsDeleted);

            return !existingAppointment;
        }

        public async Task<DoctorSchedule?> GetActiveScheduleByDoctorAndDayAsync(int? doctorId, string dayOfWeek)
        {
            return await _schedules
                .Where(x => x.DoctorId == doctorId
                    && x.DayOfWeek == dayOfWeek
                    && !x.IsDeleted
                    && x.IsActive)
                .FirstOrDefaultAsync();
        }

        public async Task<DateTime?> GetNextAvailableSlotAsync(int doctorId)
        {
            var today = DateTime.UtcNow.Date;
            var currentDate = today;

            for (int i = 0; i < 30; i++) // Check next 30 days
            {
                var dayOfWeek = currentDate.DayOfWeek.ToString();
                var schedule = await GetDoctorScheduleByDayAsync(doctorId, dayOfWeek);

                if (schedule != null)
                {
                    var availableSlots = await GetDoctorAvailableSlotsAsync(doctorId, currentDate);
                    if (availableSlots.Any())
                    {
                        return currentDate.Date + availableSlots.First();
                    }
                }
                currentDate = currentDate.AddDays(1);
            }

            return null;
        }
        #endregion
    }
}