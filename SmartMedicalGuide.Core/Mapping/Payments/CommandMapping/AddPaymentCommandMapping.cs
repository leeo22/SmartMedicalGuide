using SmartMedicalGuide.Core.Features.Payments.Commands.Models;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Payments
{
    public partial class PaymentProfile
    {
        public void AddPaymentCommandMapping()
        {
            CreateMap<AddPaymentCommand, Payment>()
                .ForMember(dest => dest.DoctorAppointmentId, opt => opt.MapFrom(src => src.DoctorAppointmentId))
                .ForMember(dest => dest.LabAppointmentId, opt => opt.MapFrom(src => src.LabAppointmentId))
                .ForMember(dest => dest.PaymentMethod, opt => opt.MapFrom(src => src.PaymentMethod))
                .ForMember(dest => dest.WalletType, opt => opt.MapFrom(src => src.WalletType))
                .ForMember(dest => dest.ReceiverName, opt => opt.MapFrom(src => src.ReceiverName))
                .ForMember(dest => dest.ReceiverNumber, opt => opt.MapFrom(src => src.ReceiverNumber))
                .ForMember(dest => dest.TransferImagePath, opt => opt.MapFrom(src => src.TransferImagePath))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount))
                .ForMember(dest => dest.PlatformFee, opt => opt.MapFrom(src => src.PlatformFee))
                .ForMember(dest => dest.DoctorShare, opt => opt.MapFrom(src => src.DoctorShare))
                .ForMember(dest => dest.Notes, opt => opt.MapFrom(src => src.Notes));
        }
    }
}