using AutoMapper;

namespace SmartMedicalGuide.Core.Mapping.Clinics
{
    public partial class ClinicProfile : Profile
    {
        public ClinicProfile()
        {
            AddClinicCommandMapping();
            EditClinicCommandMapping();
            GetClinicListResponseMapping();
            GetSingleClinicResponseMapping();
        }
    }
}