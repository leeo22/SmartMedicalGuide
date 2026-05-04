using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Payments.Queries.Models
{
    public class GetPaymentStatisticsQuery : IRequest<Response<object>>
    {
    }
}