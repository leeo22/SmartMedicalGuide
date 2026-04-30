using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Data.Requests;

namespace SmartMedicalGuide.Core.Features.Authorization.Commands.Models
{
    public class UpdateUserClaimsCommand : UpdateUserClaimsRequest, IRequest<Response<string>>
    {
    }
}
