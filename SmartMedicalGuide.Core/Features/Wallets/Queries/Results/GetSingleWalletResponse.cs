using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Features.Wallets.Queries.Results
{
    public class GetSingleWalletResponse
    {
        public int WalletId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserFullName { get; set; }
        public string UserEmail { get; set; }
        public decimal AvailableBalance { get; set; }
        public decimal WithdrawnBalance { get; set; }
        public decimal TotalBalance { get; set; }
        public string? DoctorAccountNumber { get; set; }
        public string? AccountHolderName { get; set; }
        public string? BankName { get; set; }
        public string Currency { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public ICollection<Transaction>? Transactions { get; set; }
    }
}