using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Data.Requests;

namespace SmartMedicalGuide.Core.Features.Authentication.Commands.Models
{
    public class RefreshTokenCommand : IRequest<Response<JwtAuthResult>>
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
