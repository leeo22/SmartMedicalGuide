using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Clinics.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Clinics.Queries.Models
{
    public class GetClinicByIdQuery : IRequest<Response<GetSingleClinicResponse>>
    {
        public int Id { get; set; }
        public GetClinicByIdQuery(int id) => Id = id;
    }
}