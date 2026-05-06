using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Wallets.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Wallets.Queries.Models
{
    public class GetWalletListQuery : IRequest<Response<List<GetWalletListResponse>>>
    {
        public bool? OnlyDoctors { get; set; }
        public bool? OnlyActive { get; set; }
    }
}