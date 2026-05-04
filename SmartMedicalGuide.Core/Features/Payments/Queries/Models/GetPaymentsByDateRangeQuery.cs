using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Payments.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Payments.Queries.Models
{
    public class GetPaymentsByDateRangeQuery : IRequest<Response<List<GetPaymentListResponse>>>
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}