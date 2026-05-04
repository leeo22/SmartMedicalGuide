using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.DoctorCapacitySettings.Commands.Models
{
    public class DecrementDailyCapacityCommand : IRequest<Response<bool>>
    {
        public int DoctorId { get; set; }
    }
}