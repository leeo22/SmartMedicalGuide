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

        // حذف منطقي
        public bool IsDeleted { get; set; } = false;

        // وصف المعاملة
        [MaxLength(500)]
        public string? Description { get; set; }

        // معرف المرجع المرتبط (مثلاً AppointmentId)
        public int? ReferenceId { get; set; }

        // نوع المرجع (DoctorAppointment, LabAppointment, Withdrawal)
        [MaxLength(100)]
        public string? ReferenceType { get; set; }

        // حالة المعاملة (Pending, Completed, Failed)
        [MaxLength(50)]
        public string? Status { get; set; } = "Completed";

        // رقم مرجعي للمعاملة من بوابة الدفع
        [MaxLength(100)]
        public string? TransactionReference { get; set; }
    }
}
