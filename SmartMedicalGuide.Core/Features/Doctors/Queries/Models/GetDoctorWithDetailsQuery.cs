using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Doctors.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Doctors.Queries.Models
{
    public class GetDoctorWithDetailsQuery : IRequest<Response<GetDoctorWithDetailsResponse>>
    {
        public int DoctorId { get; set; }
        public GetDoctorWithDetailsQuery(int doctorId) => DoctorId = doctorId;
    }
}