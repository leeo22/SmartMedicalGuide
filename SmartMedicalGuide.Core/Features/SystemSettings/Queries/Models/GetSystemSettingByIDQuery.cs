using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.SystemSettings.Queries.Results;


namespace SmartMedicalGuide.Core.Features.SystemSettings.Queries.Models
{
    public class GetSystemSettingByIDQuery : IRequest<Response<GetSingleSystemSettingResponse>>
    {
        public int Id { get; set; }
        public GetSystemSettingByIDQuery(int id)
        {
            Id = id;
        }
    }
}
