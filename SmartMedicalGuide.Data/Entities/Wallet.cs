using System.ComponentModel.DataAnnotations;
using SmartMedicalGuide.Data.Entities.Identity;

namespace SmartMedicalGuide.Data.Entities
{
    public class Wallet
    {
        [Key]
        public int WalletId { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }

        public decimal Balance { get; set; }
    }
}
