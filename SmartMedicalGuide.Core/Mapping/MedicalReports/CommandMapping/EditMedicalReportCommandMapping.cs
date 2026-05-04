using SmartMedicalGuide.Core.Features.MedicalReports.Commands.Models;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.MedicalReports
{
    public partial class MedicalReportProfile
    {
        public void EditMedicalReportCommandMapping()
        {
            CreateMap<EditMedicalReportCommand, MedicalReport>()
                .ForMember(dest => dest.ReportId, opt => opt.MapFrom(src => src.ReportId))
                .ForMember(dest => dest.ReportType, opt => opt.MapFrom(src => src.ReportType))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.ReportDate, opt => opt.MapFrom(src => src.ReportDate));
        }
    }
}