using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Users.Commands.Models
{
    public class AddUserCommand : IRequest<Response<string>>
    {

        public string FullName { get; set; }
        public string UserName { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        //public int RoleId { get; set; }
        //public bool IsVerified { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
