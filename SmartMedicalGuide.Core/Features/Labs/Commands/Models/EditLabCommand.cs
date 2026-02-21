using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Labs.Commands.Models
{
    public class EditLabCommand : IRequest<Response<string>>
    {
        public int LabId { get; set; }

        public int UserId { get; set; }

        public string CenterName { get; set; }
        public string CenterType { get; set; }
        public string PhoneNumber { get; set; }
        public string Location { get; set; }
        public string LicenseNumber { get; set; }
        public string VerificationStatus { get; set; }
    }
}
