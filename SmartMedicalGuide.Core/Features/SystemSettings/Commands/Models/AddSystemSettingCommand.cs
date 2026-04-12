using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.SystemSettings.Commands.Models
{
    public class AddSystemSettingCommand : IRequest<Response<string>>
    {
        public string KeyName { get; set; }
        public string Value { get; set; }
    }
}
