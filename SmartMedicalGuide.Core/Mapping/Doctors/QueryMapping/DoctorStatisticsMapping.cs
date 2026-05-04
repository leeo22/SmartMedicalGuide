using SmartMedicalGuide.Core.Features.Doctors.Queries.Results;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Mapping.Doctors
{
    public partial class DoctorProfile
    {
        public void DoctorStatisticsResponseMapping()
        {
            CreateMap<DoctorStatisticsDto, DoctorStatisticsResponse>();
        }
    }
}