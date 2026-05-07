using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Services.Implementations
{
    public class SpecializationServices : ISpecializationServices
    {
        #region Fields
        private readonly ISpecializationRepository _specializationRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IDoctorAppointmentRepository _appointmentRepository;
        #endregion

        #region Constructors
        public SpecializationServices(
            ISpecializationRepository specializationRepository,
            IDoctorRepository doctorRepository,
            IDoctorAppointmentRepository appointmentRepository)
        {
            _specializationRepository = specializationRepository;
            _doctorRepository = doctorRepository;
            _appointmentRepository = appointmentRepository;
        }
        #endregion

        #region Basic CRUD Handlers
        public async Task<List<Specialization>> GetListAsync()
        {
            try
            {
                return await _specializationRepository.GetAllSpecializationsWithIncludesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting specializations list: {ex.Message}", ex);
            }
        }

        public async Task<Specialization?> GetByIDAsync(int id)
        {
            try
            {
                if (id <= 0)
                    throw new ArgumentException("Invalid specialization ID");

                return await _specializationRepository.GetSpecializationByIdWithIncludesAsync(id);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"Invalid specialization ID: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting specialization by ID: {ex.Message}", ex);
            }
        }

        public async Task<string> AddAsync(Specialization specialization)
        {
            try
            {
                // Validation
                if (specialization == null)
                    return "Specialization data is required";

                if (string.IsNullOrWhiteSpace(specialization.Name))
                    return "Specialization name is required";

                // Check for duplicate name
                var existing = await GetByNameAsync(specialization.Name);
                if (existing != null)
                    return $"Specialization with name '{specialization.Name}' already exists";

                specialization.IsDeleted = false;
                await _specializationRepository.AddAsync(specialization);
                return "Success";
            }
            catch (Exception ex)
            {
                return $"Failed to add specialization: {ex.Message}";
            }
        }

        public async Task<string> EditAsync(Specialization specialization)
        {
            try
            {
                if (specialization == null)
                    return "Specialization data is required";

                if (specialization.SpecializationId <= 0)
                    return "Invalid specialization ID";

                var existing = await _specializationRepository.GetTableAsTracking()
                    .FirstOrDefaultAsync(x => x.SpecializationId == specialization.SpecializationId && !x.IsDeleted);

                if (existing == null)
                    return "Specialization not found";

                // Check for duplicate name
                var duplicate = await _specializationRepository.GetTableAsTracking()
                    .FirstOrDefaultAsync(x => x.Name == specialization.Name &&
                                              x.SpecializationId != specialization.SpecializationId &&
                                              !x.IsDeleted);

                if (duplicate != null)
                    return $"Another specialization with name '{specialization.Name}' already exists";

                // ✅ تحديث الخصائص مباشرة
                existing.Name = specialization.Name;
                existing.Description = specialization.Description;

                // ✅ استخدام UpdateAsync الموجود في الـ Repository
                await _specializationRepository.UpdateAsync(existing);

                return "Success";
            }
            catch (Exception ex)
            {
                return $"Failed to edit specialization: {ex.Message}";
            }
        }

        public async Task<string> DeleteAsync(Specialization specialization)
        {
            try
            {
                if (specialization == null)
                    return "Specialization data is required";

                if (specialization.SpecializationId <= 0)
                    return "Invalid specialization ID";

                var existing = await _specializationRepository.GetTableAsTracking()
                    .FirstOrDefaultAsync(x => x.SpecializationId == specialization.SpecializationId && !x.IsDeleted);

                if (existing == null)
                    return "Specialization not found";

                // Check if specialization has doctors
                var doctorsCount = await GetDoctorsCountBySpecializationAsync(existing.SpecializationId);
                if (doctorsCount > 0)
                    return $"Cannot delete specialization with {doctorsCount} associated doctors. Please reassign doctors first.";

                // Soft delete
                existing.IsDeleted = true;
                await _specializationRepository.UpdateAsync(existing);
                //await _specializationRepository.SaveChangesAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                return $"Failed to delete specialization: {ex.Message}";
            }
        }
        #endregion

        #region Additional Functions
        public async Task<Specialization?> GetByNameAsync(string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                    throw new ArgumentException("Specialization name is required");

                return await _specializationRepository.GetByNameAsync(name);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"Invalid specialization name: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting specialization by name: {ex.Message}", ex);
            }
        }

        public async Task<List<Specialization>> SearchSpecializationsAsync(string keyword)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(keyword))
                    return await GetListAsync();

                return await _specializationRepository.SearchSpecializationsAsync(keyword);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error searching specializations: {ex.Message}", ex);
            }
        }

        public async Task<int> GetDoctorsCountBySpecializationAsync(int specializationId)
        {
            try
            {
                if (specializationId <= 0)
                    throw new ArgumentException("Invalid specialization ID");

                return await _specializationRepository.GetDoctorsCountBySpecializationAsync(specializationId);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"Invalid specialization ID: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting doctors count: {ex.Message}", ex);
            }
        }

        public async Task<Specialization?> GetSpecializationWithDetailsAsync(int id)
        {
            try
            {
                if (id <= 0)
                    throw new ArgumentException("Invalid specialization ID");

                var specialization = await _specializationRepository.GetSpecializationWithDetailsAsync(id);

                if (specialization == null)
                    return null;

                // Ensure doctors are filtered (not deleted)
                specialization.Doctors = specialization.Doctors?.Where(d => !d.IsDeleted).ToList();

                return specialization;
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"Invalid specialization ID: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting specialization with details: {ex.Message}", ex);
            }
        }

        public async Task<List<Specialization>> GetPopularSpecializationsAsync(int limit)
        {
            try
            {
                if (limit <= 0)
                    limit = 10;

                var allSpecializations = await _specializationRepository.GetAllSpecializationsWithIncludesAsync();

                var specializationsWithDoctorCount = allSpecializations
                    .Select(s => new
                    {
                        Specialization = s,
                        DoctorCount = s.Doctors?.Count(d => !d.IsDeleted) ?? 0
                    })
                    .OrderByDescending(x => x.DoctorCount)
                    .Take(limit)
                    .Select(x => x.Specialization)
                    .ToList();

                return specializationsWithDoctorCount;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting popular specializations: {ex.Message}", ex);
            }
        }

        public async Task<object> GetSpecializationStatisticsAsync(int specializationId)
        {
            try
            {
                if (specializationId <= 0)
                    throw new ArgumentException("Invalid specialization ID");

                var specialization = await _specializationRepository.GetSpecializationByIdWithIncludesAsync(specializationId);

                if (specialization == null)
                    return null;

                var doctorIds = specialization.Doctors?.Where(d => !d.IsDeleted).Select(d => d.DoctorId).ToList() ?? new List<int>();

                int totalAppointments = 0;
                decimal totalRevenue = 0;

                if (doctorIds.Any())
                {
                    var appointments = await _appointmentRepository.GetTableAsTracking()
                        .Where(a => doctorIds.Contains(a.DoctorId ?? 0) && !a.IsDeleted)
                        .ToListAsync();

                    totalAppointments = appointments.Count;
                    totalRevenue = appointments.Where(a => a.Status == "Completed").Sum(a => a.Price ?? 0);
                }

                return new
                {
                    specialization.SpecializationId,
                    specialization.Name,
                    DoctorsCount = specialization.Doctors?.Count(d => !d.IsDeleted) ?? 0,
                    TotalAppointments = totalAppointments,
                    TotalRevenue = totalRevenue,
                    AverageDoctorsPerSpecialization = doctorIds.Any() ? doctorIds.Count : 0
                };
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"Invalid specialization ID: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting specialization statistics: {ex.Message}", ex);
            }
        }
        #endregion
    }
}