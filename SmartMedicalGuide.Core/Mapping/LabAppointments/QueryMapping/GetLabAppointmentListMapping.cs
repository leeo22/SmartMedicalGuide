using SmartMedicalGuide.Core.Features.LabAppointments.Queries.Results;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.LabAppointments
{
    public partial class LabAppointmentProfile
    {
        public void GetLabAppointmentListResponseMapping()
        {
            CreateMap<LabAppointment, GetLabAppointmentListResponse>()
                .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient != null && src.Patient.User != null ? src.Patient.User.FullName : src.FullName))
                .ForMember(dest => dest.LabName, opt => opt.MapFrom(src => src.Lab != null && src.Lab.User != null ? src.Lab.User.FullName : null));
        }
    }
}