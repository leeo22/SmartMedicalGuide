using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Payments.Queries.Models
{
    public class GetPlatformRevenueQuery : IRequest<Response<object>>
    {
    }
}