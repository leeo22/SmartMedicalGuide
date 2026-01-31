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
        public async Task<List<DoctorAppointment>> GetDoctorAppointmentsListAsync()
        {
            return await _services.GetDoctorAppointmentsListAsync();
        }
        #endregion

    }
}
