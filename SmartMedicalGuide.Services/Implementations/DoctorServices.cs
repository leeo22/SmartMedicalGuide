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

        #endregion

    }
}
