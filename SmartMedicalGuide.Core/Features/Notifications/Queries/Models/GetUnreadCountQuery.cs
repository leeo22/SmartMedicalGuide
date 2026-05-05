using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Notifications.Queries.Models
{
    public class GetUnreadCountQuery : IRequest<Response<int>>
    {
        public int UserId { get; set; }
    }
}