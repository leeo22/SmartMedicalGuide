using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Authentication.Queries.Models
{
    public class ConfirmEmailQuery : IRequest<Response<string>>
    {
        public int UserId { get; set; }
        public string Code { get; set; }
    }
}
