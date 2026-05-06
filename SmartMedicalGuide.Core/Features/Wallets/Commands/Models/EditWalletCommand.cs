using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Wallets.Commands.Models
{
    public class EditWalletCommand : IRequest<Response<string>>
    {
        public int WalletId { get; set; }
        public string? DoctorAccountNumber { get; set; }
        public string? AccountHolderName { get; set; }
        public string? BankName { get; set; }
        public string? Currency { get; set; }
        public bool IsActive { get; set; }
    }
}