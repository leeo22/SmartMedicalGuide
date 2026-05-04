using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.DoctorSchedules.Queries.Models
{
    public class CheckDoctorAvailabilityQuery : IRequest<Response<bool>>
    {
        public int DoctorId { get; set; }
        public DateTime DateTime { get; set; }
    }
}