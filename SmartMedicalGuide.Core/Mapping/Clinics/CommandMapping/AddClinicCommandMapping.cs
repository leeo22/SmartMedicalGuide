using SmartMedicalGuide.Core.Features.Clinics.Commands.Models;
using SmartMedicalGuide.Core.Features.Labs.Commands.Models;
using SmartMedicalGuide.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMedicalGuide.Core.Mapping.Clinics
{
    public partial class ClinicProfile
    {
        public void AddClinicCommandMapping()
        {
            CreateMap<AddClinicCommand, Clinic>()
                        .ForMember(dest => dest.UserId, opt => opt
                        .MapFrom(src => src.UserId));
        }
    }
}
