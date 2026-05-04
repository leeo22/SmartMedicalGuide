using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.DoctorSchedules.Queries.Results;

namespace SmartMedicalGuide.Core.Features.DoctorSchedules.Queries.Models
{
    public class GetDoctorScheduleListQuery : IRequest<Response<List<GetDoctorScheduleListResponse>>>
    {
        public int? DoctorId { get; set; }
        public string? DayOfWeek { get; set; }
    }
}