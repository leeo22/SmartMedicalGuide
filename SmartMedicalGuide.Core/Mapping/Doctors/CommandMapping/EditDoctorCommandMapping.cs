using SmartMedicalGuide.Core.Features.Doctors.Commands.Models;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Doctors

{
    public partial class DoctorProfile
    {
        public void EditDoctorCommandMapping()
        {
            CreateMap<EditDoctorCommand, Doctor>().ForMember(dest => dest.DoctorId, opt => opt
                                                  .MapFrom(src => src.DoctorId))
                                                  .ForMember(dest => dest.UserId, opt => opt
                                                  .MapFrom(src => src.UserId));

        }

    }
}
