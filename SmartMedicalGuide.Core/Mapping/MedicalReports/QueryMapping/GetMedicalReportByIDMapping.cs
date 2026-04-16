using SmartMedicalGuide.Core.Features.MedicalReports.Queries.Results;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.MedicalReports
{
    public partial class MedicalReportProfile
    {
        public void GetMedicalReportByIDMapping()
        {
            CreateMap<MedicalReport, GetSingleMedicalReportResponse>()
                .ForMember(dest => dest.ReportId, opt => opt.MapFrom(src => src.ReportId))
                .ForMember(dest => dest.PatientId, opt => opt.MapFrom(src => src.PatientId))
                //.ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient != null && src.Patient.User != null ? src.Patient.User.FullName : null))
                //.ForMember(dest => dest.PatientEmail, opt => opt.MapFrom(src => src.Patient != null && src.Patient.User != null ? src.Patient.User.Email : null))
                .ForMember(dest => dest.DoctorId, opt => opt.MapFrom(src => src.DoctorId))
                //.ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor != null && src.Doctor.User != null ? src.Doctor.User.FullName : null))
                //.ForMember(dest => dest.DoctorEmail, opt => opt.MapFrom(src => src.Doctor != null && src.Doctor.User != null ? src.Doctor.User.Email : null))
                .ForMember(dest => dest.LabId, opt => opt.MapFrom(src => src.LabId))
                //.ForMember(dest => dest.LabName, opt => opt.MapFrom(src => src.Lab != null ? src.Lab.CenterName : null))
                //.ForMember(dest => dest.LabCenterName, opt => opt.MapFrom(src => src.Lab != null ? src.Lab.CenterName : null))
                .ForMember(dest => dest.FilePath, opt => opt.MapFrom(src => src.FilePath))
                .ForMember(dest => dest.ReportType, opt => opt.MapFrom(src => src.ReportType))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt));
        }
    }
}