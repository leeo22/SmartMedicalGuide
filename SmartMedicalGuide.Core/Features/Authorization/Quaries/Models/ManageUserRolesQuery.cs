using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Data.Results;

namespace SmartMedicalGuide.Core.Features.Authorization.Quaries.Models
{
    public class ManageUserRolesQuery : IRequest<Response<ManageUserRolesResult>>
    {
        public int UserId { get; set; }
    }
}
