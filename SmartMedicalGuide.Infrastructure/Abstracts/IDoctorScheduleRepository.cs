using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Abstracts
{
    public interface IDoctorScheduleRepository : IGenericRepositoryAsync<DoctorSchedule>
    {
        //public Task<List<DoctorSchedule>> GetDoctorSchedulesListAsync();
    }
}
