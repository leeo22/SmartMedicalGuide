using Microsoft.EntityFrameworkCore;
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
            var patient = _patientRepository.GetByIdAsync()
                                            .Where(x => x.PatientId.Equals(id))
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
            var patient = _patientRepository.GetByIdAsync()
                                                  .Where(x => x.UserId.Equals(phone))
                                                  .FirstOrDefault();
            if (patient == null) return false;
            return true;

        }

        public async Task<bool> IsPhoneExistExcludeSelf(string phone, int Id)
        {
            var patient = await _patientRepository.GetByIdAsync()
                                                  .Where(x => x.UserId.Equals(phone) & !x.PatientId.Equals(Id))
                                                  .FirstOrDefaultAsync();
            if (patient == null) return false;
            return true;
        }

        public async Task<string> EditAsync(Patient patient)
        {
            await _patientRepository.UpdateAsync(patient);
            return "Success";
        }

        public async Task<string> DeleteAsync(Patient patient)
        {
            var trans = _patientRepository.BeginTransaction();
            try
            {
                await _patientRepository.DeleteAsync(patient);
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
#region Fields
#endregion
#region Constructors
#endregion
#region Handels Functions
#endregion

