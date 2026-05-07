using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Transactions.Queries.Models
{
    public class GetTransactionStatisticsQuery : IRequest<Response<object>>
    {
    }
}