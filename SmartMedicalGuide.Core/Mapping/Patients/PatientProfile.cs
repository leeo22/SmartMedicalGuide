using AutoMapper;

namespace SmartMedicalGuide.Core.Mapping.Patients
{
    public partial class PatientProfile : Profile
    {
        public PatientProfile()
        {
            GetPatientListMapping();
            GetPatientByIDMapping();
            AddPatientMappung();
        }
    }
}
