using AutoMapper;

namespace SmartMedicalGuide.Core.Mapping.Reports
{
    public partial class ReportProfile : Profile
    {
        public ReportProfile()
        {
            EditReportCommandMapping();
            AddReportCommandMapping();
            GetReportListMapping();
            GetReportByIDMapping();
        }
    }
}
