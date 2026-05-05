using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Clinics.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Clinics.Queries.Models
{
    public class GetClinicWithDoctorQuery : IRequest<Response<GetSingleClinicResponse>>
    {
        public int Id { get; set; }
        public GetClinicWithDoctorQuery(int id) => Id = id;
    }
}