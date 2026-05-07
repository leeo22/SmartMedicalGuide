using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Transactions.Commands.Models
{
    public class DeleteTransactionCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteTransactionCommand(int id) => Id = id;
    }
}