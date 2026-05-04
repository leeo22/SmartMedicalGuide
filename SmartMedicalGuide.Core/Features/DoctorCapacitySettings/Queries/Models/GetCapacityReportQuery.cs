using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.DoctorCapacitySettings.Queries.Results;

namespace SmartMedicalGuide.Core.Features.DoctorCapacitySettings.Queries.Models
{
    public class GetCapacityReportQuery : IRequest<Response<List<GetDoctorCapacitySettingListResponse>>>
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}