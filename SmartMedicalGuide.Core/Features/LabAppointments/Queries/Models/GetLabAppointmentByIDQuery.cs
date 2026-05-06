using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.LabAppointments.Queries.Results;

namespace SmartMedicalGuide.Core.Features.LabAppointments.Queries.Models
{
    public class GetLabAppointmentByIdQuery : IRequest<Response<GetSingleLabAppointmentResponse>>
    {
        public int Id { get; set; }
        public GetLabAppointmentByIdQuery(int id) => Id = id;
    }
}