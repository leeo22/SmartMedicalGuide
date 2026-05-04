using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Payments.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Payments.Queries.Models
{
    public class GetPaymentsByPatientIdQuery : IRequest<Response<List<GetPaymentListResponse>>>
    {
        public int PatientId { get; set; }
    }
}