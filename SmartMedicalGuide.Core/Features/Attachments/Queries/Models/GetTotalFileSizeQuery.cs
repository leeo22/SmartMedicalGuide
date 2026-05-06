using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Attachments.Queries.Models
{
    public class GetTotalFileSizeQuery : IRequest<Response<long>>
    {
        public int UserId { get; set; }
    }
}