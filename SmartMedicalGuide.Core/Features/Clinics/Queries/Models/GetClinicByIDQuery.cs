using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Clinics.Queries.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMedicalGuide.Core.Features.Clinics.Queries.Models
{
    public class GetClinicByIDQuery : IRequest<Response<GetSingleClinicResponse>>
    {
        public int Id { get; set; }
        public GetClinicByIDQuery(int id)
        {
            Id = id;
        }
    }
}
