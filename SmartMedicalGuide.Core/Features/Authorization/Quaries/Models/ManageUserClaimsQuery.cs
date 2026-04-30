using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Data.Results;

namespace SmartMedicalGuide.Core.Features.Authorization.Quaries.Models
{
    public class ManageUserClaimsQuery : IRequest<Response<ManageUserClaimsResult>>
    {
        public int UserId { get; set; }
    }
}
