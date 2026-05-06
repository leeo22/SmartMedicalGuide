using SmartMedicalGuide.Core.Features.PrescriptionItems.Queries.Results;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.PrescriptionItems
{
    public partial class PrescriptionItemProfile
    {
        public void GetPrescriptionItemWithDetailsResponseMapping()
        {
            CreateMap<PrescriptionItem, GetPrescriptionItemWithDetailsResponse>()
                .ForMember(dest => dest.PrescriptionDescription, opt => opt.MapFrom(src => src.Prescription != null ? src.Prescription.Description : null))
                .ForMember(dest => dest.PrescriptionCreatedAt, opt => opt.MapFrom(src => src.Prescription != null ? src.Prescription.CreatedAt : DateTime.MinValue))
                .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Prescription != null && src.Prescription.Doctor != null && src.Prescription.Doctor.User != null ? src.Prescription.Doctor.User.FullName : null))
                .ForMember(dest => dest.DoctorEmail, opt => opt.MapFrom(src => src.Prescription != null && src.Prescription.Doctor != null && src.Prescription.Doctor.User != null ? src.Prescription.Doctor.User.Email : null))
                .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Prescription != null && src.Prescription.Patient != null && src.Prescription.Patient.User != null ? src.Prescription.Patient.User.FullName : null))
                .ForMember(dest => dest.PatientEmail, opt => opt.MapFrom(src => src.Prescription != null && src.Prescription.Patient != null && src.Prescription.Patient.User != null ? src.Prescription.Patient.User.Email : null));
        }
    }
}