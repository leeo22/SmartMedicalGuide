using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartMedicalGuide.Data.Entities
{

    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        public int? DoctorAppointmentId { get; set; }
        public DoctorAppointment? DoctorAppointment { get; set; }


        public int? LabAppointmentId { get; set; }
        public LabAppointment? LabAppointment { get; set; }
        public string? PaymentMethod { get; set; }
        public string? WalletType { get; set; }
        public string? ReceiverName { get; set; }
        public string? ReceiverNumber { get; set; }
        public string? TransferImagePath { get; set; }

        public string? PaymentStatus { get; set; }
        public DateTime PaymentDate { get; set; }
        // سعر الدفع (نسخة محفوظة بجانب الموعد)
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        // رقم مرجعي للمعاملة من بوابة الدفع
        [MaxLength(100)]
        public string? TransactionId { get; set; }

        // حذف منطقي
        public bool IsDeleted { get; set; } = false;

        // ملاحظات إضافية على الدفع
        public string? Notes { get; set; }

        // رسوم المنصة (إن وجدت)
        [Column(TypeName = "decimal(18,2)")]
        public decimal PlatformFee { get; set; }

        // حصة الدكتور من المبلغ
        [Column(TypeName = "decimal(18,2)")]
        public decimal DoctorShare { get; set; }
    }


}
