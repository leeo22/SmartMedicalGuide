using SmartMedicalGuide.Data.Entities.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartMedicalGuide.Data.Entities
{
    public class Wallet
    {
        [Key]
        public int WalletId { get; set; }

        [Required]
        public int UserId { get; set; }
        public virtual User? User { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal WithdrawnBalance { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal AvailableBalance { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalBalance { get; set; } = 0;

        [MaxLength(100)]
        public string? DoctorAccountNumber { get; set; }

        // ✅ الحقول الجديدة المضافة
        public bool IsDeleted { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        [MaxLength(3)]
        public string Currency { get; set; } = "SAR";

        [MaxLength(200)]
        public string? AccountHolderName { get; set; }

        [MaxLength(100)]
        public string? BankName { get; set; }

        public bool IsActive { get; set; } = true;

        // Navigation Properties
        public virtual ICollection<Transaction>? Transactions { get; set; }
    }
}