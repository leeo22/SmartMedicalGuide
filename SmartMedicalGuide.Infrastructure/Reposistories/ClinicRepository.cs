using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Infrastructure.Context;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMedicalGuide.Infrastructure.Reposistories
{
    public class ClinicRepository : GenericRepositoryAsync<Clinic>, IClinicRepository
    {
        #region Fields
        private readonly DbSet<Clinic> _clinic;
        #endregion

        #region Constructors
        public ClinicRepository(MedicalGuideDbContext dBContext) : base(dBContext)
        {
            _clinic = dBContext.Set<Clinic>();

        }

        #endregion

        #region Handels Functions

        public async Task<List<Clinic>> GetClinicsListAsync()
        {
            return await _clinic.ToListAsync();//Edit
        }
        #endregion


    }
}
