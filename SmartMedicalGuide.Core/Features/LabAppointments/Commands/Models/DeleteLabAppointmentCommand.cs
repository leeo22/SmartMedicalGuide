using MediatR;
using SmartMedicalGuide.Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMedicalGuide.Core.Features.LabAppointments.Commands.Models
{
    public class DeleteLabAppointmentCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteLabAppointmentCommand(int id)
        {
            Id = id;

        }
    }
}
