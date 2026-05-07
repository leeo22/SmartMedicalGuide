using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Services.Implementations
{
    public class PatientServices : IPatientServices
    {
        #region Fields
        private readonly IPatientRepository _patientRepository;
        private readonly IDoctorAppointmentRepository _doctorAppointmentRepository;
        private readonly ILabAppointmentRepository _labAppointmentRepository;
        private readonly IPrescriptionRepository _prescriptionRepository;
        private readonly IMedicalReportRepository _medicalReportRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IFavoriteRepository _favoriteRepository;
        private readonly IReviewRepository _reviewRepository;
        #endregion

        #region Constructors
        public PatientServices(
            IPatientRepository patientRepository,
            IDoctorAppointmentRepository doctorAppointmentRepository,
            ILabAppointmentRepository labAppointmentRepository,
            IPrescriptionRepository prescriptionRepository,
            IMedicalReportRepository medicalReportRepository,
            IPaymentRepository paymentRepository,
            IFavoriteRepository favoriteRepository,
            IReviewRepository reviewRepository)
        {
            _patientRepository = patientRepository;
            _doctorAppointmentRepository = doctorAppointmentRepository;
            _labAppointmentRepository = labAppointmentRepository;
            _prescriptionRepository = prescriptionRepository;
            _medicalReportRepository = medicalReportRepository;
            _paymentRepository = paymentRepository;
            _favoriteRepository = favoriteRepository;
            _reviewRepository = reviewRepository;
        }
        #endregion

        #region Basic CRUD Handlers
        public async Task<List<Patient>> GetListAsync()
        {
            return await _patientRepository.GetAllPatientsWithIncludesAsync();
        }

        public async Task<Patient?> GetByIDAsync(int id)
        {
            return await _patientRepository.GetPatientByIdWithIncludesAsync(id);
        }

        public async Task<string> AddAsync(Patient patient)
        {
            var existingPatient = await _patientRepository.GetTableAsTracking()
                .FirstOrDefaultAsync(x => x.UserId == patient.UserId && !x.IsDeleted);

            if (existingPatient != null)
                return "User is already registered as a patient";

            patient.IsDeleted = false;
            await _patientRepository.AddAsync(patient);
            return "Success";
        }

        public async Task<string> EditAsync(Patient patient)
        {
            var existingPatient = await _patientRepository.GetTableAsTracking()
                .FirstOrDefaultAsync(x => x.PatientId == patient.PatientId && !x.IsDeleted);

            if (existingPatient == null)
                return "Patient not found";

            existingPatient.Gender = patient.Gender;
            existingPatient.DateOfBirth = patient.DateOfBirth;
            existingPatient.Address = patient.Address;

            await _patientRepository.UpdateAsync(existingPatient);
            return "Success";
        }

        public async Task<string> DeleteAsync(Patient patient)
        {
            patient.IsDeleted = true;
            await _patientRepository.UpdateAsync(patient);
            return "Success";
        }
        #endregion

        #region Additional Functions
        public async Task<Patient?> GetByUserIdAsync(int userId)
        {
            return await _patientRepository.GetByUserIdAsync(userId);
        }

        public async Task<object> GetPatientAppointmentsAsync(int patientId)
        {
            var doctorAppointments = await _doctorAppointmentRepository.GetTableAsTracking()
                .Include(x => x.Doctor)
                    .ThenInclude(d => d.User)
                .Where(x => x.PatientId == patientId)
                .ToListAsync();

            var labAppointments = await _labAppointmentRepository.GetTableAsTracking()
                .Include(x => x.Lab)
                    .ThenInclude(l => l.User)
                .Where(x => x.PatientId == patientId)
                .ToListAsync();

            return new { DoctorAppointments = doctorAppointments, LabAppointments = labAppointments };
        }

        public async Task<object> GetPatientPrescriptionsAsync(int patientId)
        {
            var prescriptions = await _prescriptionRepository.GetTableAsTracking()
                .Include(x => x.Doctor)
                    .ThenInclude(d => d.User)
                .Include(x => x.DoctorAppointment)
                .Where(x => x.PatientId == patientId)
                .ToListAsync();

            return prescriptions;
        }

        public async Task<object> GetPatientMedicalReportsAsync(int patientId)
        {
            var reports = await _medicalReportRepository.GetTableAsTracking()
                .Include(x => x.Doctor)
                    .ThenInclude(d => d.User)
                .Include(x => x.Lab)
                    .ThenInclude(l => l.User)
                .Where(x => x.PatientId == patientId)
                .ToListAsync();

            return reports;
        }

        public async Task<object> GetPatientPaymentHistoryAsync(int patientId)
        {
            var doctorAppointmentIds = await _doctorAppointmentRepository.GetTableAsTracking()
                .Where(x => x.PatientId == patientId)
                .Select(x => x.AppointmentId)
                .ToListAsync();

            var labAppointmentIds = await _labAppointmentRepository.GetTableAsTracking()
                .Where(x => x.PatientId == patientId)
                .Select(x => x.LabAppointmentId)
                .ToListAsync();

            var payments = await _paymentRepository.GetTableAsTracking()
                .Where(x => (x.DoctorAppointmentId.HasValue && doctorAppointmentIds.Contains(x.DoctorAppointmentId.Value)) ||
                            (x.LabAppointmentId.HasValue && labAppointmentIds.Contains(x.LabAppointmentId.Value)))
                .ToListAsync();

            return payments;
        }

        public async Task<object> GetPatientUpcomingAppointmentsAsync(int patientId)
        {
            var now = DateTime.UtcNow;

            var doctorAppointments = await _doctorAppointmentRepository.GetTableAsTracking()
                .Include(x => x.Doctor)
                    .ThenInclude(d => d.User)
                .Where(x => x.PatientId == patientId && x.AppointmentDate > now && x.Status != "Cancelled")
                .OrderBy(x => x.AppointmentDate)
                .ToListAsync();

            var labAppointments = await _labAppointmentRepository.GetTableAsTracking()
                .Include(x => x.Lab)
                    .ThenInclude(l => l.User)
                .Where(x => x.PatientId == patientId && x.AppointmentDate > now && x.Status != "Cancelled")
                .OrderBy(x => x.AppointmentDate)
                .ToListAsync();

            return new { DoctorAppointments = doctorAppointments, LabAppointments = labAppointments };
        }

        public async Task<object> GetPatientPastAppointmentsAsync(int patientId)
        {
            var now = DateTime.UtcNow;

            var doctorAppointments = await _doctorAppointmentRepository.GetTableAsTracking()
                .Include(x => x.Doctor)
                    .ThenInclude(d => d.User)
                .Where(x => x.PatientId == patientId && x.AppointmentDate < now)
                .OrderByDescending(x => x.AppointmentDate)
                .ToListAsync();

            var labAppointments = await _labAppointmentRepository.GetTableAsTracking()
                .Include(x => x.Lab)
                    .ThenInclude(l => l.User)
                .Where(x => x.PatientId == patientId && x.AppointmentDate < now)
                .OrderByDescending(x => x.AppointmentDate)
                .ToListAsync();

            return new { DoctorAppointments = doctorAppointments, LabAppointments = labAppointments };
        }

        public async Task<object> GetPatientFavoriteDoctorsAsync(int patientId)
        {
            var favorites = await _favoriteRepository.GetTableAsTracking()
                .Include(x => x.Doctor)
                    .ThenInclude(d => d.User)
                .Where(x => x.PatientId == patientId)
                .ToListAsync();

            return favorites;
        }

        public async Task<object> GetPatientReviewsAsync(int patientId)
        {
            var reviews = await _reviewRepository.GetTableAsTracking()
                .Where(x => x.PatientId == patientId)
                .ToListAsync();

            return reviews;
        }

        public async Task<object> GetPatientStatisticsAsync(int patientId)
        {
            var doctorAppointments = await _doctorAppointmentRepository.GetTableAsTracking()
                .Where(x => x.PatientId == patientId)
                .ToListAsync();

            var labAppointments = await _labAppointmentRepository.GetTableAsTracking()
                .Where(x => x.PatientId == patientId)
                .ToListAsync();

            var prescriptions = await _prescriptionRepository.GetTableAsTracking()
                .Where(x => x.PatientId == patientId)
                .ToListAsync();

            var totalAppointments = doctorAppointments.Count + labAppointments.Count;
            var completedAppointments = doctorAppointments.Count(x => x.Status == "Completed") + labAppointments.Count(x => x.Status == "Completed");
            var cancelledAppointments = doctorAppointments.Count(x => x.Status == "Cancelled") + labAppointments.Count(x => x.Status == "Cancelled");
            var pendingAppointments = doctorAppointments.Count(x => x.Status == "Pending") + labAppointments.Count(x => x.Status == "Pending");

            return new
            {
                PatientId = patientId,
                TotalAppointments = totalAppointments,
                CompletedAppointments = completedAppointments,
                CancelledAppointments = cancelledAppointments,
                PendingAppointments = pendingAppointments,
                TotalPrescriptions = prescriptions.Count
            };
        }

        public async Task<string> UpdatePatientProfileAsync(int patientId, string? gender, DateTime? dateOfBirth, string? address)
        {
            var patient = await _patientRepository.GetByIdAsync()
                .FirstOrDefaultAsync(x => x.PatientId == patientId && !x.IsDeleted);

            if (patient == null)
                return "Patient not found";

            if (!string.IsNullOrEmpty(gender))
                patient.Gender = gender;

            if (dateOfBirth.HasValue)
                patient.DateOfBirth = dateOfBirth.Value;

            if (!string.IsNullOrEmpty(address))
                patient.Address = address;

            await _patientRepository.UpdateAsync(patient);
            return "Success";
        }

        public async Task<List<Patient>> SearchPatientsAsync(string keyword)
        {
            return await _patientRepository.SearchPatientsAsync(keyword);
        }
        #endregion
    }
}