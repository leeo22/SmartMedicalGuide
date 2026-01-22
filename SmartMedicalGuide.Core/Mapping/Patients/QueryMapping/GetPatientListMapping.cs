using SmartMedicalGuide.Core.Features.Patients.Queries.Results;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Patients
{
    public partial class PatientProfile
    {
        public void GetPatientListMapping()
        {
            CreateMap<Patient, GetPatientListResponse>();
        }
    }
}
