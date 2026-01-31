using SmartMedicalGuide.Core.Features.Payments.Commands.Models;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Payments
{
    public partial class PaymentProfile
    {
        public void AddPaymentCommandMapping()
        {
            CreateMap<AddPaymentCommand, Payment>();


        }

    }
}