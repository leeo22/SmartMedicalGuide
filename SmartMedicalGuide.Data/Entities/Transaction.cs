using System.ComponentModel.DataAnnotations;

namespace SmartMedicalGuide.Data.Entities
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        public int WalletId { get; set; }
        public Wallet? Wallet { get; set; }

        public decimal Amount { get; set; }
        public string? Type { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
