using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.DoctorSchedules.Queries.Results;

namespace SmartMedicalGuide.Core.Features.DoctorSchedules.Queries.Models
{
    public class GetDoctorScheduleByIdQuery : IRequest<Response<GetSingleDoctorScheduleResponse>>
    {
        public int Id { get; set; }
        public GetDoctorScheduleByIdQuery(int id) => Id = id;
    }
}