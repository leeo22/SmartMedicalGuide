using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Prescriptions.Queries.Models
{
    public class GetPrescriptionStatisticsQuery : IRequest<Response<object>>
    {
    }
}