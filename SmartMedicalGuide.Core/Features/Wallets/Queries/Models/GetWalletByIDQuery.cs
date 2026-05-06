using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Wallets.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Wallets.Queries.Models
{
    public class GetWalletByIdQuery : IRequest<Response<GetSingleWalletResponse>>
    {
        public int Id { get; set; }
        public GetWalletByIdQuery(int id) => Id = id;
    }
}