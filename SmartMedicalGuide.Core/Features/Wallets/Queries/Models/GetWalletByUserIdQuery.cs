using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Wallets.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Wallets.Queries.Models
{
    public class GetWalletByUserIdQuery : IRequest<Response<GetSingleWalletResponse>>
    {
        public int UserId { get; set; }
    }
}