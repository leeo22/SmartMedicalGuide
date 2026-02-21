using System.ComponentModel.DataAnnotations;

namespace SmartMedicalGuide.Data.Entities
{

    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        // FK لحجز الطبيب (يكون واحد فقط منهم غير null)
        public int? DoctorAppointmentId { get; set; }
        public DoctorAppointment DoctorAppointment { get; set; }

        // FK لحجز المختبر
        public int? LabAppointmentId { get; set; }
        public LabAppointment LabAppointment { get; set; }

        public string PaymentMethod { get; set; }
        public string WalletType { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverNumber { get; set; }
        public string TransferImagePath { get; set; }

        public string PaymentStatus { get; set; }
        public DateTime PaymentDate { get; set; }
    }


}
