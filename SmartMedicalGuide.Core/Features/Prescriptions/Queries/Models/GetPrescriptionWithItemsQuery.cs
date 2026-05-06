using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Prescriptions.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Prescriptions.Queries.Models
{
    public class GetPrescriptionWithItemsQuery : IRequest<Response<GetPrescriptionWithItemsResponse>>
    {
        public int Id { get; set; }
        public GetPrescriptionWithItemsQuery(int id) => Id = id;
    }
}