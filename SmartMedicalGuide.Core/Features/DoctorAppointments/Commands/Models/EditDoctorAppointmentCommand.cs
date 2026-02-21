using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.DoctorAppointments.Commands.Models
{
    public class EditDoctorAppointmentCommand : IRequest<Response<string>>
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public string PaymentStatus { get; set; }
        public string AppointmentType { get; set; }
    }
}
