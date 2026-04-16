using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Reviews.Commands.Models
{
    public class EditReviewCommand : IRequest<Response<string>>
    {
        public int ReviewId { get; set; }
        public int PatientId { get; set; }
        public string TargetType { get; set; }
        public int TargetId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}