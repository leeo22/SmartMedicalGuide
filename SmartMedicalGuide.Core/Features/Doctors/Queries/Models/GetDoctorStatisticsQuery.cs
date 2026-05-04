using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Doctors.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Doctors.Queries.Models
{
    public class GetDoctorStatisticsQuery : IRequest<Response<DoctorStatisticsResponse>>
    {
        public int DoctorId { get; set; }
        public GetDoctorStatisticsQuery(int doctorId) => DoctorId = doctorId;
    }
}