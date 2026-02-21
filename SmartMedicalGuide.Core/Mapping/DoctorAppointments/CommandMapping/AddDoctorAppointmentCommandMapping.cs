using SmartMedicalGuide.Core.Features.DoctorAppointments.Commands.Models;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.DoctorAppointments
{
    public partial class DoctorAppointmentProfile
    {

        public void AddDoctorAppointmentCommandMapping()
        {
            CreateMap<AddDoctorAppointmentCommand, DoctorAppointment>()
                .ForMember(dest => dest.PatientId, opt => opt
                .MapFrom(src => src.PatientId))
                .ForMember(dest => dest.DoctorId, opt => opt
                .MapFrom(src => src.DoctorId));
        }
    }
}
