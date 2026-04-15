using SmartMedicalGuide.Core.Features.Reports.Commands.Models;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Reports
{
    public partial class ReportProfile
    {
        public void EditReportCommandMapping()
        {
            CreateMap<EditReportCommand, Report>();
        }
    }
}
