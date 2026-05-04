using SmartMedicalGuide.Core.Features.MedicalReports.Queries.Results;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.MedicalReports
{
    public partial class MedicalReportProfile
    {
        public void GetPatientMedicalHistoryResponseMapping()
        {
            CreateMap<MedicalReport, GetPatientMedicalHistoryResponse>()
                .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor != null && src.Doctor.User != null ? src.Doctor.User.FullName : null));
        }
    }
}