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
    public class LabAppointmentServices : ILabAppointmentServices
    {

        #region Fields
        public readonly ILabAppointmentRepository _labAppointmentRepository;
        #endregion

        #region Constructors
        public LabAppointmentServices(ILabAppointmentRepository labAppointmentRepository)
        {
            _labAppointmentRepository = labAppointmentRepository;
        }


        #endregion



        #region Handels Functions

        public async Task<string> AddAsync(LabAppointment labAppointment)
        {

            await _labAppointmentRepository.AddAsync(labAppointment);
            return "Success";
        }

        public async Task<string> DeleteAsync(LabAppointment labAppointment)
        {
            var trans = _labAppointmentRepository.BeginTransaction();
            try
            {
                await _labAppointmentRepository.DeleteAsync(labAppointment);
                await trans.CommitAsync();
                return "Success";
            }
            catch
            {
                await trans.RollbackAsync();
                return "Falied";
            }
        }

        public async Task<string> EditAsync(LabAppointment labAppointment)
        {
            await _labAppointmentRepository.UpdateAsync(labAppointment);
            return "Success";
        }

        public async Task<LabAppointment> GetLabAppointmentsByIDAsync(int id)
        {
            var labAppointment = _labAppointmentRepository.GetByIdAsync()
                                            .Where(x => x.LabAppointmentId.Equals(id))
                                            .FirstOrDefault();
            return labAppointment;
        }

        public async Task<List<LabAppointment>> GetLabAppointmentsListAsync()
        {
            return await _labAppointmentRepository.GetLabAppointmentsListAsync();
        }
        #endregion
    }
}

