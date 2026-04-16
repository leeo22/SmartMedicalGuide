using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Notifications.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Notifications.Queries.Models
{
    public class GetNotificationByIDQuery : IRequest<Response<GetSingleNotificationResponse>>
    {
        public int Id { get; set; }
        public GetNotificationByIDQuery(int id) => Id = id;
    }
}