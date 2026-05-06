using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Reviews.Commands.Models
{
    public class AddReviewCommand : IRequest<Response<string>>
    {
        public int PatientId { get; set; }
        public string TargetType { get; set; }  // "Doctor" or "Lab"
        public int TargetId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
    }
}