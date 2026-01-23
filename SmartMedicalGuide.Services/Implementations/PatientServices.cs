using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Services.Implementations
{
    public class PatientServices : IPatientServices
    {
        #region Fields
        public readonly IPatientRepository _patientRepository;
        #endregion

        #region Constructors
        public PatientServices(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }


        #endregion

        #region Handels Functions
        public async Task<List<Patient>> GetPatientsListAsync()
        {
            return await _patientRepository.GetAllPatientsListAsync();
        }

        public async Task<Patient> GetPatientByIdAsync(int id)
        {
            var patient = _patientRepository.GetTableNoTracking()
                                            .Where(x => x.PatientID.Equals(id))
                                            .FirstOrDefault();
            return patient;
        }

        public async Task<string> AddAsync(Patient patient)
        {

            await _patientRepository.AddAsync(patient);
            return "Success";


        }

        public async Task<bool> IsPhoneExist(string phone)
        {
            var patient = _patientRepository.GetTableNoTracking()
                                                  .Where(x => x.Phone.Equals(phone))
                                                  .FirstOrDefault();
            if (patient == null) return false;
            return true;




        }
        #endregion




    }

}

