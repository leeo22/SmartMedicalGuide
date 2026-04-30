using SmartMedicalGuide.Core.Bases;
using MediatR;

namespace SmartMedicalGuide.Core.Features.Authentication.Queries.Models
{
    public class AuthorizeUserQuery : IRequest<Response<string>>
    {
        public string AccessToken { get; set; }
    }
}
