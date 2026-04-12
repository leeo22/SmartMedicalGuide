using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.SystemSettings.Queries.Results;

namespace SmartMedicalGuide.Core.Features.SystemSettings.Queries.Models
{
    public class GetSystemSettingListQuery : IRequest<Response<List<GetSystemSettingListResponse>>>
    {
    }
}
