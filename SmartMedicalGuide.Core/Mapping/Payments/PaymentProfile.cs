using AutoMapper;

namespace SmartMedicalGuide.Core.Mapping.Payments
{
    public partial class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            AddPaymentCommandMapping();
            EditPaymentCommandMapping();
            GetPaymentListResponseMapping();
            GetSinglePaymentResponseMapping();
        }
    }
}