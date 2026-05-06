using SmartMedicalGuide.Core.Features.Prescriptions.Queries.Results;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Prescriptions
{
    public partial class PrescriptionProfile
    {
        public void GetPrescriptionWithItemsResponseMapping()
        {
            CreateMap<Prescription, GetPrescriptionWithItemsResponse>()
                .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor != null && src.Doctor.User != null ? src.Doctor.User.FullName : null))
                .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient != null && src.Patient.User != null ? src.Patient.User.FullName : null))
                .ForMember(dest => dest.PrescriptionItems, opt => opt.Ignore());
        }
    }
}