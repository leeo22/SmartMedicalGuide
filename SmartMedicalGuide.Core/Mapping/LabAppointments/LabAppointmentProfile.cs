using AutoMapper;

namespace SmartMedicalGuide.Core.Mapping.LabAppointments
{
    public partial class LabAppointmentProfile : Profile
    {
        public LabAppointmentProfile()
        {
            AddLabAppointmentCommandMapping();
            EditLabAppointmentCommandMapping();
            GetLabAppointmentListResponseMapping();
            GetSingleLabAppointmentResponseMapping();
        }
    }
}