using SmartMedicalGuide.Core.Features.Prescriptions.Commands.Models;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Prescriptions
{
    public partial class PrescriptionProfile
    {
        public void AddPrescriptionCommandMapping()
        {
            CreateMap<AddPrescriptionCommand, Prescription>()
                .ForMember(dest => dest.DoctorAppointmentId, opt => opt.MapFrom(src => src.DoctorAppointmentId))
                .ForMember(dest => dest.DoctorId, opt => opt.MapFrom(src => src.DoctorId))
                .ForMember(dest => dest.PatientId, opt => opt.MapFrom(src => src.PatientId))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Notes, opt => opt.MapFrom(src => src.Notes))
                .ForMember(dest => dest.FollowUpDate, opt => opt.MapFrom(src => src.FollowUpDate));
        }
    }
}