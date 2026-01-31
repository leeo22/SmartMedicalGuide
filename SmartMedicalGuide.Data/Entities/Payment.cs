using System.ComponentModel.DataAnnotations;

namespace SmartMedicalGuide.Data.Entities
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        public AppointmentType AppointmentType { get; set; }
        public int AppointmentId { get; set; }

        public string PaymentMethod { get; set; }
        public string WalletType { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverNumber { get; set; }
        public string TransferImagePath { get; set; }

        public string PaymentStatus { get; set; }
        public DateTime PaymentDate { get; set; }
    }
    public enum AppointmentType
    {
        Doctor = 1,
        Lab = 2
    }

}
