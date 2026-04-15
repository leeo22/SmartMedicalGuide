using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.AppointmentHistories.Queries.Results;

namespace SmartMedicalGuide.Core.Features.AppointmentHistories.Queries.Models
{
    public class GetAppointmentHistoryByIDQuery : IRequest<Response<GetSingleAppointmentHistoryResponse>>
    {
        public int Id { get; set; }
        public GetAppointmentHistoryByIDQuery(int id) => Id = id;
    }
}