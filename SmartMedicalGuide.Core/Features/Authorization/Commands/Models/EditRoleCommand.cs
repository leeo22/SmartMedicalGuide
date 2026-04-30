using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Data.DTOs;

namespace SmartMedicalGuide.Core.Features.Authorization.Commands.Models
{
    public class EditRoleCommand : EditRoleRequest, IRequest<Response<string>>
    {

    }
}
