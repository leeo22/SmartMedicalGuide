using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Abstracts
{
    public interface IDoctorAppointmentRepository : IGenericRepositoryAsync<DoctorAppointment>
    {
        Task<List<DoctorAppointment>> GetDoctorAppointmentsListAsync();
    }
}
