using SmartMedicalGuide.Core.Features.Prescriptions.Queries.Results;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Prescriptions
{
    public partial class PrescriptionProfile
    {
        public void GetPrescriptionListMapping()
        {
            CreateMap<Prescription, GetPrescriptionListResponse>()
                .ForMember(dest => dest.PrescriptionId, opt => opt.MapFrom(src => src.PrescriptionId))
                .ForMember(dest => dest.PatientId, opt => opt.MapFrom(src => src.PatientId))
                //.ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient != null && src.Patient.User != null ? src.Patient.User.FullName : null))
                .ForMember(dest => dest.DoctorId, opt => opt.MapFrom(src => src.DoctorId))
                //.ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor != null && src.Doctor.User != null ? src.Doctor.User.FullName : null))
                .ForMember(dest => dest.DoctorAppointmentId, opt => opt.MapFrom(src => src.DoctorAppointmentId))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt));
            //.ForMember(dest => dest.ItemsCount, opt => opt.MapFrom(src => src.PrescriptionItems != null ? src.PrescriptionItems.Count : 0));
        }
    }
}