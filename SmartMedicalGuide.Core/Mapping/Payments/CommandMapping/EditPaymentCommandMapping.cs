using SmartMedicalGuide.Core.Features.Payments.Commands.Models;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Payments
{
    public partial class PaymentProfile
    {
        public void EditPaymentCommandMapping()
        {
            CreateMap<EditPaymentCommand, Payment>()
                .ForMember(dest => dest.PaymentId, opt => opt.MapFrom(src => src.PaymentId))
                .ForMember(dest => dest.PaymentMethod, opt => opt.MapFrom(src => src.PaymentMethod))
                .ForMember(dest => dest.WalletType, opt => opt.MapFrom(src => src.WalletType))
                .ForMember(dest => dest.ReceiverName, opt => opt.MapFrom(src => src.ReceiverName))
                .ForMember(dest => dest.ReceiverNumber, opt => opt.MapFrom(src => src.ReceiverNumber))
                .ForMember(dest => dest.TransferImagePath, opt => opt.MapFrom(src => src.TransferImagePath))
                .ForMember(dest => dest.PaymentStatus, opt => opt.MapFrom(src => src.PaymentStatus))
                .ForMember(dest => dest.Notes, opt => opt.MapFrom(src => src.Notes));
        }
    }
}