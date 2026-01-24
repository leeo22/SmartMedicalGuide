using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Patients.Commands.Models
{
    public class EditPatientCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int? Age { get; set; }
        public string Phone { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
