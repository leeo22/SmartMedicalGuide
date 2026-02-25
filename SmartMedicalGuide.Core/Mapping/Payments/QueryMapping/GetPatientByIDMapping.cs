using SmartMedicalGuide.Core.Features.Payments.Queries.Results;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Payments
{
    public partial class PaymentProfile
    {
        public void GetPatientByIDMapping()
        {
            CreateMap<Payment, GetSinglePaymentResponse>();
        }
    }
}
