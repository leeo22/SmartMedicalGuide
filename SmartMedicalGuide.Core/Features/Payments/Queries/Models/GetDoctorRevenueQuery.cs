using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Payments.Queries.Models
{
    public class GetDoctorRevenueQuery : IRequest<Response<decimal>>
    {
        public int DoctorId { get; set; }
    }
}