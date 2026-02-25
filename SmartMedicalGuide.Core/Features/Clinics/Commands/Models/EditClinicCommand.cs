using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMedicalGuide.Core.Features.Clinics.Commands.Models
{
    public class EditClinicCommand : IRequest<Response<string>>
    {
        public int ClinicId { get; set; }

        public int UserId { get; set; }

        public string ClinicName { get; set; }

        public string Location { get; set; }
        public string PhoneNumber { get; set; }
       
        

    }
}
