using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Wallets.Commands.Models
{
    public class DeleteWalletCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteWalletCommand(int id) => Id = id;
    }
}