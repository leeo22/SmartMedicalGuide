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

        #endregion

        #region Constructors
        public DoctorServices(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }


        #endregion

        #region Handels Functions
        public async Task<List<Doctor>> GetDoctorsListAsync()
        {
            return await _doctorRepository.GetDoctorsListAsync();
        }
        public async Task<string> AddAsync(Doctor doctor)
        {
            await _doctorRepository.AddAsync(doctor);
            return "Success";
        }

        public async Task<Doctor?> GetDoctorByIDAsync(int id)
        {
            var doctor = _doctorRepository.GetByIdAsync()
                                      .Include(x => x.User)
                                      //.ThenInclude(r => r.Role)
                                      .Where(x => x.DoctorId.Equals(id))
                                      .FirstOrDefault();
            return doctor;
        }

        public async Task<string> EditAsync(Doctor doctor)
        {
            await _doctorRepository.UpdateAsync(doctor);
            return "Success";
        }

        public async Task<string> DeleteAsync(Doctor doctor)
        {
            var trans = _doctorRepository.BeginTransaction();
            try
            {
                await _doctorRepository.DeleteAsync(doctor);
                await trans.CommitAsync();
                return "Success";
            }
            catch
            {
                await trans.RollbackAsync();
                return "Falied";
            }
        }


        #endregion

    }
}
