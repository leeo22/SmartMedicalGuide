using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Services.Implementations
{
    public class DoctorAppointmentServices : IDoctorAppointmentServices
    {
        #region Fields
        private readonly IDoctorAppointmentRepository _appointmentRepository;
        #endregion

        #region Constructors
        public DoctorAppointmentServices(IDoctorAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }
        #endregion

        #region Basic CRUD Handlers
        public async Task<List<DoctorAppointment>> GetListAsync()
        {
            return await _appointmentRepository.GetAllAppointmentsWithIncludesAsync();
        }

        public async Task<DoctorAppointment?> GetByIDAsync(int id)
        {
            return await _appointmentRepository.GetAppointmentByIdWithIncludesAsync(id);
        }

        public async Task<string> AddAsync(DoctorAppointment appointment)
        {
            appointment.Status = appointment.Status ?? "Pending";
            appointment.IsDeleted = false;
            await _appointmentRepository.AddAsync(appointment);
            return "Success";
        }

        public async Task<string> EditAsync(DoctorAppointment appointment)
        {
            var existing = await _appointmentRepository.GetTableAsTracking()
                .FirstOrDefaultAsync(x => x.AppointmentId == appointment.AppointmentId && !x.IsDeleted);

            if (existing == null)
                return "Appointment not found";

            existing.AppointmentDate = appointment.AppointmentDate;
            existing.Price = appointment.Price;
            existing.Status = appointment.Status;
            existing.AppointmentType = appointment.AppointmentType;
            existing.FullName = appointment.FullName;
            existing.Age = appointment.Age;
            existing.Gender = appointment.Gender;
            existing.PhoneNumber = appointment.PhoneNumber;
            existing.BookingSource = appointment.BookingSource;
            existing.IsPostponed = appointment.IsPostponed;
            existing.NewAppointmentDate = appointment.NewAppointmentDate;
            existing.OriginalAppointmentDate = appointment.OriginalAppointmentDate;
            existing.PostponeReason = appointment.PostponeReason;
            existing.CancellationReason = appointment.CancellationReason;

            await _appointmentRepository.UpdateAsync(existing);
            return "Success";
        }

        public async Task<string> DeleteAsync(DoctorAppointment appointment)
        {
            appointment.IsDeleted = true;
            await _appointmentRepository.UpdateAsync(appointment);
            return "Success";
        }
        #endregion

        #region Additional Functions
        // أضف هذه الدالة

        public async Task<List<DoctorAppointment>> GetByDoctorIdAsync(int doctorId)
        {
            return await _appointmentRepository.GetByDoctorIdAsync(doctorId);
        }

        public async Task<List<DoctorAppointment>> GetByPatientIdAsync(int patientId)
        {
            return await _appointmentRepository.GetByPatientIdAsync(patientId);
        }

        public async Task<List<DoctorAppointment>> GetByDateAsync(DateTime date)
        {
            return await _appointmentRepository.GetByDateAsync(date);
        }

        public async Task<List<DoctorAppointment>> GetByStatusAsync(string status)
        {
            return await _appointmentRepository.GetByStatusAsync(status);
        }

        public async Task<List<DoctorAppointment>> GetDoctorUpcomingAppointmentsAsync(int doctorId)
        {
            return await _appointmentRepository.GetDoctorUpcomingAppointmentsAsync(doctorId);
        }

        public async Task<List<DoctorAppointment>> GetPatientUpcomingAppointmentsAsync(int patientId)
        {
            return await _appointmentRepository.GetPatientUpcomingAppointmentsAsync(patientId);
        }

        public async Task<List<DoctorAppointment>> GetDoctorTodayAppointmentsAsync(int doctorId)
        {
            return await _appointmentRepository.GetDoctorTodayAppointmentsAsync(doctorId);
        }

        public async Task<List<DoctorAppointment>> GetDoctorAppointmentsByDateRangeAsync(int doctorId, DateTime fromDate, DateTime toDate)
        {
            return await _appointmentRepository.GetDoctorAppointmentsByDateRangeAsync(doctorId, fromDate, toDate);
        }

        public async Task<int> GetDoctorAppointmentsCountAsync(int doctorId)
        {
            return await _appointmentRepository.GetDoctorAppointmentsCountAsync(doctorId);
        }

        public async Task<bool> CheckDoctorAvailabilityAsync(int doctorId, DateTime appointmentDate)
        {
            return await _appointmentRepository.CheckDoctorAvailabilityAsync(doctorId, appointmentDate);
        }

        public async Task<object> GetAppointmentsReportAsync(DateTime? fromDate, DateTime? toDate)
        {
            return await _appointmentRepository.GetAppointmentsReportAsync(fromDate, toDate);
        }

        public async Task<string> CancelAppointmentAsync(int appointmentId, string? cancellationReason = null, int? rescheduledByUserId = null)
        {
            var appointment = await _appointmentRepository.GetByIdAsync()
                .FirstOrDefaultAsync(x => x.AppointmentId == appointmentId && !x.IsDeleted);

            if (appointment == null)
                return "Appointment not found";

            appointment.Status = "Cancelled";
            appointment.CancellationReason = cancellationReason;
            appointment.RescheduledByUserId = rescheduledByUserId;

            await _appointmentRepository.UpdateAsync(appointment);
            return "Success";
        }

        public async Task<string> ConfirmAppointmentAsync(int appointmentId)
        {
            var appointment = await _appointmentRepository.GetByIdAsync()
                .FirstOrDefaultAsync(x => x.AppointmentId == appointmentId && !x.IsDeleted);

            if (appointment == null)
                return "Appointment not found";

            appointment.Status = "Confirmed";
            await _appointmentRepository.UpdateAsync(appointment);
            return "Success";
        }

        public async Task<string> CompleteAppointmentAsync(int appointmentId)
        {
            var appointment = await _appointmentRepository.GetByIdAsync()
                .FirstOrDefaultAsync(x => x.AppointmentId == appointmentId && !x.IsDeleted);

            if (appointment == null)
                return "Appointment not found";

            appointment.Status = "Completed";
            await _appointmentRepository.UpdateAsync(appointment);
            return "Success";
        }

        public async Task<string> RescheduleAppointmentAsync(int appointmentId, DateTime newDate, string? reason = null, int? rescheduledByUserId = null)
        {
            var appointment = await _appointmentRepository.GetByIdAsync()
                .FirstOrDefaultAsync(x => x.AppointmentId == appointmentId && !x.IsDeleted);

            if (appointment == null)
                return "Appointment not found";

            appointment.IsPostponed = true;
            appointment.OriginalAppointmentDate = appointment.AppointmentDate;
            appointment.NewAppointmentDate = newDate;
            appointment.AppointmentDate = newDate;
            appointment.PostponeReason = reason;
            appointment.RescheduledByUserId = rescheduledByUserId;

            await _appointmentRepository.UpdateAsync(appointment);
            return "Success";
        }
        #endregion
    }
}