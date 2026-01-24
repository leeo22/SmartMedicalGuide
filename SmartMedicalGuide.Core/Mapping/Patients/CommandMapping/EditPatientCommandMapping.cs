using SmartMedicalGuide.Core.Features.Patients.Commands.Models;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Patients
{
    public partial class PatientProfile
    {
        public void EditPatientCommandMapping()
        {
            CreateMap<EditPatientCommand, Patient>()
                .ForMember(dest => dest.PatientID, opt => opt.MapFrom(src => src.Id));
        }

    }
}
