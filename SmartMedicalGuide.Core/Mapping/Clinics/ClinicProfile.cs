using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMedicalGuide.Core.Mapping.Clinics
{
    public partial class ClinicProfile : Profile
    {
        public ClinicProfile()
        {
            EditClinicCommandMapping();
            AddClinicCommandMapping();
            GetClinicByIDMapping();
            GetClinicListMapping();
        }
    }
}
