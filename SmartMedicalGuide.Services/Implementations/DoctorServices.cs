using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Services.Implementations
{
    public class DoctorServices : IDoctorServices
    {
        #region Fields
        private readonly IDoctorRepository _doctorRepository;
        private readonly IDoctorAppointmentRepository _appointmentRepository;
        private readonly IPrescriptionRepository _prescriptionRepository;
        #endregion

        #region Constructors
        public DoctorServices(
            IDoctorRepository doctorRepository,
            IDoctorAppointmentRepository appointmentRepository,
            IPrescriptionRepository prescriptionRepository)
        {
            _doctorRepository = doctorRepository;
            _appointmentRepository = appointmentRepository;
            _prescriptionRepository = prescriptionRepository;
        }
        #endregion

        #region Basic CRUD Handlers
        public async Task<List<Doctor>> GetListAsync()
        {
            return await _doctorRepository.GetAllDoctorsWithIncludesAsync();
        }

        public async Task<Doctor?> GetByIDAsync(int id)
        {
            return await _doctorRepository.GetDoctorByIdWithIncludesAsync(id);
        }

        public async Task<string> AddAsync(Doctor doctor)
        {
            var existingDoctor = await _doctorRepository.GetTableAsTracking()
                .FirstOrDefaultAsync(x => x.UserId == doctor.UserId && !x.IsDeleted);

            if (existingDoctor != null)
                return "User is already registered as a doctor";

            doctor.VerificationStatus = "Pending";
            doctor.IsDeleted = false;
            doctor.IsAvailableForBooking = true;

            await _doctorRepository.AddAsync(doctor);
            return "Success";
        }

        public async Task<string> EditAsync(Doctor doctor)
        {
            var existingDoctor = await _doctorRepository.GetByIdAsync()
                .FirstOrDefaultAsync(x => x.DoctorId == doctor.DoctorId && !x.IsDeleted);

            if (existingDoctor == null)
                return "Doctor not found";

            existingDoctor.SpecializationId = doctor.SpecializationId;
            existingDoctor.Bio = doctor.Bio;
            existingDoctor.LicenseNumber = doctor.LicenseNumber;
            existingDoctor.ConsultationPrice = doctor.ConsultationPrice;
            existingDoctor.AvailableTimes = doctor.AvailableTimes;
            existingDoctor.YearsOfExperience = doctor.YearsOfExperience;
            existingDoctor.Gender = doctor.Gender;
            existingDoctor.ProfileImageUrl = doctor.ProfileImageUrl;

            await _doctorRepository.UpdateAsync(existingDoctor);
            return "Success";
        }

        public async Task<string> DeleteAsync(Doctor doctor)
        {
            // Soft delete
            doctor.IsDeleted = true;
            await _doctorRepository.UpdateAsync(doctor);
            return "Success";
        }
        #endregion

        #region Additional Functions
        public async Task<int> GetTotalTreatedPatientsCountAsync(int doctorId)
        {
            return await _appointmentRepository.GetTotalTreatedPatientsCountAsync(doctorId);
        }
        public async Task<Doctor?> GetByUserIdAsync(int userId)
        {
            return await _doctorRepository.GetByUserIdAsync(userId);
        }

        public async Task<List<Doctor>> GetBySpecializationIdAsync(int specializationId)
        {
            return await _doctorRepository.GetBySpecializationIdAsync(specializationId);
        }

        public async Task<List<Doctor>> GetVerifiedDoctorsAsync()
        {
            return await _doctorRepository.GetVerifiedDoctorsAsync();
        }

        public async Task<List<Doctor>> SearchDoctorsAsync(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return await GetListAsync();
            return await _doctorRepository.SearchDoctorsAsync(keyword);
        }

        public async Task<List<Doctor>> GetTopRatedDoctorsAsync(int limit)
        {
            return await _doctorRepository.GetTopRatedDoctorsAsync(limit);
        }

        public async Task<List<Doctor>> GetDoctorsByPriceRangeAsync(decimal minPrice, decimal maxPrice)
        {
            return await _doctorRepository.GetDoctorsByPriceRangeAsync(minPrice, maxPrice);
        }

        public async Task<List<Doctor>> GetAvailableForBookingDoctorsAsync()
        {
            return await _doctorRepository.GetAvailableForBookingDoctorsAsync();
        }

        public async Task<string> UpdateVerificationStatusAsync(int doctorId, string status)
        {
            var doctor = await _doctorRepository.GetByIdAsync().FirstOrDefaultAsync(x => x.DoctorId == doctorId && !x.IsDeleted);
            if (doctor == null)
                return "Doctor not found";

            doctor.VerificationStatus = status;
            await _doctorRepository.UpdateAsync(doctor);
            return "Success";
        }

        public async Task<string> ToggleAvailableForBookingAsync(int doctorId, bool isAvailable)
        {
            var doctor = await _doctorRepository.GetByIdAsync().FirstOrDefaultAsync(x => x.DoctorId == doctorId && !x.IsDeleted);
            if (doctor == null)
                return "Doctor not found";

            doctor.IsAvailableForBooking = isAvailable;
            await _doctorRepository.UpdateAsync(doctor);
            return "Success";
        }

        public async Task<Doctor?> GetDoctorWithDetailsAsync(int id)
        {
            return await _doctorRepository.GetDoctorWithDetailsAsync(id);
        }

        public async Task<DoctorStatisticsDto> GetDoctorStatisticsAsync(int doctorId)
        {
            var doctor = await _doctorRepository.GetByIdAsync().FirstOrDefaultAsync(x => x.DoctorId == doctorId && !x.IsDeleted);
            if (doctor == null)
                return null;

            var appointments = await _appointmentRepository.GetTableAsTracking()
                .Where(x => x.DoctorId == doctorId)
                .ToListAsync();

            var prescriptions = await _prescriptionRepository.GetTableAsTracking()
                .Where(x => x.DoctorId == doctorId)
                .ToListAsync();

            return new DoctorStatisticsDto
            {
                DoctorId = doctorId,
                DoctorName = doctor.User?.FullName ?? "Unknown",
                Gender = doctor.Gender,
                YearsOfExperience = doctor.YearsOfExperience,
                TotalAppointments = appointments.Count,
                CompletedAppointments = appointments.Count(x => x.Status == "Completed"),
                CancelledAppointments = appointments.Count(x => x.Status == "Cancelled"),
                PendingAppointments = appointments.Count(x => x.Status == "Pending"),
                TotalRevenue = appointments.Where(x => x.Status == "Completed").Sum(x => x.Price ?? 0),
                AverageRating = doctor.Reviews != null && doctor.Reviews.Any() ? doctor.Reviews.Average(r => r.Rating) : 0,
                TotalReviews = doctor.Reviews?.Count ?? 0,
                TotalPrescriptions = prescriptions.Count
            };
        }
        #endregion
    }
}