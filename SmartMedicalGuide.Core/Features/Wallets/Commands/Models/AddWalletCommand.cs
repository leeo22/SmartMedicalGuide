using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Wallets.Commands.Models
{
    public class AddWalletCommand : IRequest<Response<string>>
    {
        public int UserId { get; set; }
        public string? DoctorAccountNumber { get; set; }
        public string? AccountHolderName { get; set; }
        public string? BankName { get; set; }
        public string? Currency { get; set; }
    }
}