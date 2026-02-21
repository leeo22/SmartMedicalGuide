using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Services.Implementations
{
    internal class DoctorAppointmentServices : IDoctorAppointmentServices
    {
        #region Fields
        private readonly IDoctorAppointmentRepository _services;
        #endregion
        #region Constructors
        public DoctorAppointmentServices(IDoctorAppointmentRepository services)
        {
            _services = services;
        }


        #endregion
        #region Handels Functions
        public async Task<string> AddAsync(DoctorAppointment doctorAppointment)
        {
            await _services.AddAsync(doctorAppointment);
            return "Success";
        }

        public async Task<string> DeleteAsync(DoctorAppointment doctorAppointment)
        {
            var trans = _services.BeginTransaction();
            try
            {
                await _services.DeleteAsync(doctorAppointment);
                await trans.CommitAsync();
                return "Success";
            }
            catch
            {
                await trans.RollbackAsync();
                return "Falied";
            }
        }

        public async Task<string> EditAsync(DoctorAppointment doctorAppointment)
        {
            await _services.UpdateAsync(doctorAppointment);
            return "Success";
        }

        public async Task<DoctorAppointment> GetDoctorAppointmentByIDAsync(int id)
        {
            var doctorAppointment = _services.GetByIdAsync()
                                      .Include(x => x.Patient)
                                      .Include(x => x.Doctor)
                                      .Where(x => x.AppointmentId.Equals(id))
                                      .FirstOrDefault();
            return doctorAppointment;
        }

        public async Task<List<DoctorAppointment>> GetDoctorAppointmentsListAsync()
        {
            return await _services.GetDoctorAppointmentsListAsync();
        }
        #endregion

    }
}
