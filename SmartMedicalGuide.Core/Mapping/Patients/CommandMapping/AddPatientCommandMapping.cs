using SmartMedicalGuide.Core.Features.Patients.Commands.Models;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Patients
{
    public partial class PatientProfile
    {
        public void AddPatientMappung()
        {
            CreateMap<AddPatientCommand, Patient>()
                .ForMember(dest => dest.UserId, opt => opt
                        .MapFrom(src => src.UserId));
        }
    }
}
