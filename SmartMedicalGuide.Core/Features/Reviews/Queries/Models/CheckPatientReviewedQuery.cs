using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Reviews.Queries.Models
{
    public class CheckPatientReviewedQuery : IRequest<Response<bool>>
    {
        public int PatientId { get; set; }
        public string TargetType { get; set; }
        public int TargetId { get; set; }
    }
}