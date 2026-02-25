using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMedicalGuide.Core.Features.Clinics.Queries.Results
{
    public class GetSingleClinicResponse
    {

        public string UserName { get; set; }
        public string RoleName { get; set; }

        public int ClinicId { get; set; }
        public string ClinicName { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
    }
}
