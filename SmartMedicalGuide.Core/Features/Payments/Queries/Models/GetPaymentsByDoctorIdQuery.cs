using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Payments.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Payments.Queries.Models
{
    public class GetPaymentsByDoctorIdQuery : IRequest<Response<List<GetPaymentListResponse>>>
    {
        public int DoctorId { get; set; }
    }
}