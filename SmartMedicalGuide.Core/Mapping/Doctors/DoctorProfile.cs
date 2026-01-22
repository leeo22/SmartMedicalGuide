using AutoMapper;


namespace SmartMedicalGuide.Core.Mapping.Doctors
{
    public partial class DoctorProfile : Profile
    {
        public DoctorProfile()
        {
            GetDoctorListMapping();
        }

    }
}
