using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Payments.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Payments.Queries.Models
{
    public class GetPaymentsByMethodQuery : IRequest<Response<List<GetPaymentListResponse>>>
    {
        public string Method { get; set; }
    }
}