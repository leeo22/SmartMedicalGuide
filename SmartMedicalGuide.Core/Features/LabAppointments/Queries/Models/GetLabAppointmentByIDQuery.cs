using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.DoctorAppointments.Queries.Results;
using SmartMedicalGuide.Core.Features.LabAppointments.Queries.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMedicalGuide.Core.Features.LabAppointments.Queries.Models
{
    public class GetLabAppointmentByIDQuery : IRequest<Response<GetSingleLabAppointmentResponse>>
    {
        public int Id { get; set; }
        public GetLabAppointmentByIDQuery(int id)
        {
            Id = id;
        }
    }
}
