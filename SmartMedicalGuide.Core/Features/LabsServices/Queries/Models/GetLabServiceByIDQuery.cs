using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.LabsServices.Queries.Results;

namespace SmartMedicalGuide.Core.Features.LabsServices.Queries.Models
{
    public class GetLabServiceByIDQuery : IRequest<Response<GetSingleLabServiceResponse>>
    {
        public int Id { get; set; }

        public GetLabServiceByIDQuery(int id)
        {
            Id = id;
        }
    }
}