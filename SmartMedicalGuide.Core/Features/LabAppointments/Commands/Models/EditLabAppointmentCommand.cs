using MediatR;
using SmartMedicalGuide.Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMedicalGuide.Core.Features.LabAppointments.Commands.Models
{
    public class EditLabAppointmentCommand : IRequest<Response<string>>
    {
        public int PatientId { get; set; }
        public int LabAppointmentId { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        public DateTime AppointmentDate { get; set; }
        public string TestType { get; set; }
        public string Status { get; set; }
        public decimal Price { get; set; }
    }
    
}
