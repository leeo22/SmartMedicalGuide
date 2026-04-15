using SmartMedicalGuide.Core.Features.Reports.Queries.Results;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Reports
{
    public partial class ReportProfile
    {
        public void GetReportListMapping()
        {
            CreateMap<Report, GetReportListResponse>();
        }
    }
}
