using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.DoctorCapacitySettings.Queries.Models
{
    public class GetRemainingCapacityQuery : IRequest<Response<int>>
    {
        public int DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }
    }
}