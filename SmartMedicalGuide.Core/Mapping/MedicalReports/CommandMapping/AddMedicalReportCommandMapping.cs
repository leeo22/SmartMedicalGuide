using SmartMedicalGuide.Core.Features.MedicalReports.Commands.Models;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.MedicalReports
{
    public partial class MedicalReportProfile
    {
        public void AddMedicalReportCommandMapping()
        {
            CreateMap<AddMedicalReportCommand, MedicalReport>()
                .ForMember(dest => dest.PatientId, opt => opt.MapFrom(src => src.PatientId))
                .ForMember(dest => dest.DoctorId, opt => opt.MapFrom(src => src.DoctorId))
                .ForMember(dest => dest.ReportType, opt => opt.MapFrom(src => src.ReportType))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.ReportDate, opt => opt.MapFrom(src => src.ReportDate));
        }
    }
}