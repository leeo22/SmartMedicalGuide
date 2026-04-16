using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Prescriptions.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Prescriptions.Queries.Models
{
    public class GetPrescriptionByIDQuery : IRequest<Response<GetSinglePrescriptionResponse>>
    {
        public int Id { get; set; }
        public GetPrescriptionByIDQuery(int id) => Id = id;
    }
}