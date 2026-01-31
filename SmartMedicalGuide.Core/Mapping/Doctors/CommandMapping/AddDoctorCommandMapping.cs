using SmartMedicalGuide.Core.Features.Doctors.Commands.Models;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Doctors

{
    public partial class DoctorProfile
    {
        public void AddDoctorCommandMapping()
        {
            CreateMap<AddDoctorCommand, Doctor>()
                        .ForMember(dest => dest.UserId, opt => opt
                        .MapFrom(src => src.UserId));
        }
    }
}