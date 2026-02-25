using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Payments.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Payments.Queries.Models
{
    public class GetPaymentByIDQuery : IRequest<Response<GetSinglePaymentResponse>>
    {
        public int Id { get; set; }
        public GetPaymentByIDQuery(int id)
        {
            Id = id;
        }
    }
}
