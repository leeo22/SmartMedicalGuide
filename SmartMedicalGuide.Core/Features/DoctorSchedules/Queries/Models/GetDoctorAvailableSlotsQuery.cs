using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.DoctorSchedules.Queries.Models
{
    public class GetDoctorAvailableSlotsQuery : IRequest<Response<List<string>>>
    {
        public int DoctorId { get; set; }
        public DateTime Date { get; set; }
    }
}