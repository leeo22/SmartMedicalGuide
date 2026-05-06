using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Wallets.Queries.Models
{
    public class GetWalletStatisticsQuery : IRequest<Response<object>>
    {
    }
}