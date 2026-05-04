using AutoMapper;

namespace SmartMedicalGuide.Core.Mapping.MedicalReports
{
    public partial class MedicalReportProfile : Profile
    {
        public MedicalReportProfile()
        {
            AddMedicalReportCommandMapping();
            EditMedicalReportCommandMapping();
            GetMedicalReportListResponseMapping();
            GetPatientMedicalHistoryResponseMapping();
        }
    }
}