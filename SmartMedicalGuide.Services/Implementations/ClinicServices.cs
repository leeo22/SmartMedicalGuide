using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Infrastructure.Reposistories;
using SmartMedicalGuide.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMedicalGuide.Services.Implementations
{
    public class ClinicServices : IClinicServices
    {
        #region Fields
        public readonly IClinicRepository _clinicRepository;
        #endregion

        #region Constructors
        public ClinicServices(IClinicRepository clinicRepository)
        {
            _clinicRepository = clinicRepository;
        }


        #endregion

        #region Handels Functions
        public async Task<string> AddAsync(Clinic clinic)
        {
            await _clinicRepository.AddAsync(clinic);
            return "Success";

        }

        public async Task<string> DeleteAsync(Clinic clinic)
        {
            var trans = _clinicRepository.BeginTransaction();
            try
            {
                await _clinicRepository.DeleteAsync(clinic);
                await trans.CommitAsync();
                return "Success";
            }
            catch
            {
                await trans.RollbackAsync();
                return "Falied";
            }
        }

        public async Task<string> EditAsync(Clinic clinic)
        {
            await _clinicRepository.UpdateAsync(clinic);
            return "Success";
        }

        public async Task<Clinic> GetClinicByIDAsync(int id)
        {
            var clinic = _clinicRepository.GetByIdAsync()
                                             .Where(x => x.ClinicId.Equals(id))
                                             .FirstOrDefault();
            return clinic;
        }

        public async Task<List<Clinic>> GetClinicsListAsync()
        {
            return await _clinicRepository.GetClinicsListAsync();
        }
        #endregion
    }
}
