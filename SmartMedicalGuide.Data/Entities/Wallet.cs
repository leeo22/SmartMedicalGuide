using SmartMedicalGuide.Data.Entities.Identity;
using System.ComponentModel.DataAnnotations;

namespace SmartMedicalGuide.Data.Entities
{
    public class Wallet
    {
        [Key]
        public int WalletId { get; set; }

        public int UserId { get; set; }

        public User? User { get; set; }

        public decimal TotalBalance { get; set; }

        public decimal WithdrawnBalance { get; set; }

        public decimal AvailableBalance { get; set; }

        public string? DoctorAccountNumber { get; set; }
    }
}
