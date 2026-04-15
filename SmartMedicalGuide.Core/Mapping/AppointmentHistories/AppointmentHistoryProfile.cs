using AutoMapper;

namespace SmartMedicalGuide.Core.Mapping.AppointmentHistories
{
    public partial class AppointmentHistoryProfile : Profile
    {
        public AppointmentHistoryProfile()
        {
            AddAppointmentHistoryCommandMapping();
            EditAppointmentHistoryCommandMapping();
            GetAppointmentHistoryByIDMapping();
            GetAppointmentHistoryListMapping();
        }
    }
}