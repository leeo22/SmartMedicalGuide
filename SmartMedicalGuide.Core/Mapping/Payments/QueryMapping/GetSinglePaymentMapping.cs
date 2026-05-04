using SmartMedicalGuide.Core.Features.Payments.Queries.Results;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Payments
{
    public partial class PaymentProfile
    {
        public void GetSinglePaymentResponseMapping()
        {
            CreateMap<Payment, GetSinglePaymentResponse>()
                .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src =>
                    src.DoctorAppointment != null && src.DoctorAppointment.Patient != null && src.DoctorAppointment.Patient.User != null ? src.DoctorAppointment.Patient.User.FullName :
                    src.LabAppointment != null && src.LabAppointment.Patient != null && src.LabAppointment.Patient.User != null ? src.LabAppointment.Patient.User.FullName : null))
                .ForMember(dest => dest.PatientEmail, opt => opt.MapFrom(src =>
                    src.DoctorAppointment != null && src.DoctorAppointment.Patient != null && src.DoctorAppointment.Patient.User != null ? src.DoctorAppointment.Patient.User.Email :
                    src.LabAppointment != null && src.LabAppointment.Patient != null && src.LabAppointment.Patient.User != null ? src.LabAppointment.Patient.User.Email : null))
                .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src =>
                    src.DoctorAppointment != null && src.DoctorAppointment.Doctor != null && src.DoctorAppointment.Doctor.User != null ? src.DoctorAppointment.Doctor.User.FullName : null))
                .ForMember(dest => dest.DoctorEmail, opt => opt.MapFrom(src =>
                    src.DoctorAppointment != null && src.DoctorAppointment.Doctor != null && src.DoctorAppointment.Doctor.User != null ? src.DoctorAppointment.Doctor.User.Email : null))
                .ForMember(dest => dest.LabName, opt => opt.MapFrom(src =>
                    src.LabAppointment != null && src.LabAppointment.Lab != null && src.LabAppointment.Lab.User != null ? src.LabAppointment.Lab.User.FullName : null));
        }
    }
}