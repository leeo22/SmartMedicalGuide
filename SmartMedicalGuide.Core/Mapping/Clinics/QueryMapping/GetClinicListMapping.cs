using SmartMedicalGuide.Core.Features.Clinics.Queries.Results;
using SmartMedicalGuide.Core.Features.Labs.Queries.Results;
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
        public void GetClinicListMapping()
        {
            CreateMap<Clinic, GetClinicListResponse>()
                .ForMember(dest => dest.RoleName, opt => opt
                .MapFrom(src => src.User.Role.RoleName))
                .ForMember(dest => dest.UserName, opt => opt
                .MapFrom(src => src.User.FullName));
        }
    }
}
