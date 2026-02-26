using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Features.Clinics.Commands.Models
{
    public class AddClinicCommand : IRequest<Response<string>>
    {
        public string ClinicName { get; set; }

        public int UserId { get; set; }

        public string Location { get; set; }
        public string PhoneNumber { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
