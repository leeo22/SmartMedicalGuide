using SmartMedicalGuide.Core.Features.Doctors.Queries.Results;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Doctors
{
    public partial class DoctorProfile
    {
        public void GetDoctorListMapping()
        {
            CreateMap<Doctor, GetDoctorListRespones>();
        }
    }
}
