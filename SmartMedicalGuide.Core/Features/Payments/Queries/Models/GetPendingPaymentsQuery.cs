using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Payments.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Payments.Queries.Models
{
    public class GetPendingPaymentsQuery : IRequest<Response<List<GetPaymentListResponse>>>
    {
    }
}