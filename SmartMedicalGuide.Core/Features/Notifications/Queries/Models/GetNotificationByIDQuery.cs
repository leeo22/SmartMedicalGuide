using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Notifications.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Notifications.Queries.Models
{
    public class GetNotificationByIdQuery : IRequest<Response<GetSingleNotificationResponse>>
    {
        public int Id { get; set; }
        public GetNotificationByIdQuery(int id) => Id = id;
    }
}