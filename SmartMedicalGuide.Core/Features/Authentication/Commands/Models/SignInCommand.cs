using SmartMedicalGuide.Core.Bases;
using MediatR;
using SmartMedicalGuide.Data.Requests;

namespace SmartMedicalGuide.Core.Features.Authentication.Commands.Models
{
    public class SignInCommand : IRequest<Response<JwtAuthResult>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
