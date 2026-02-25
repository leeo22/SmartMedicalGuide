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
    public class LabAppointmentRepository : GenericRepositoryAsync<LabAppointment>, ILabAppointmentRepository
    {
        #region Fields
        private readonly DbSet<LabAppointment> _labAppointment;
        #endregion

        #region Constructors
        public LabAppointmentRepository(MedicalGuideDbContext dBContext) : base(dBContext)
        {
            _labAppointment = dBContext.Set<LabAppointment>();

        }
        #endregion

        #region Handels Functions
        public async Task<List<LabAppointment>> GetLabAppointmentsListAsync()
        {
            return await _labAppointment.ToListAsync();
        }
        #endregion
    }
}
