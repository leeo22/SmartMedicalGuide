using AutoMapper;

namespace SmartMedicalGuide.Core.Mapping.DoctorAppointments
{
    public partial class DoctorAppointmentProfile : Profile
    {
        public DoctorAppointmentProfile()
        {
            GetDoctorAppointmentListMapping();
            AddDoctorAppointmentCommandMapping();
        }

    }
}
