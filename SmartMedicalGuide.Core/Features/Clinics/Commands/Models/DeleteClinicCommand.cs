using MediatR;
using SmartMedicalGuide.Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMedicalGuide.Core.Features.Clinics.Commands.Models
{
    public class DeleteClinicCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteClinicCommand(int id)
        {
            Id = id;

        }
    }
}
