using SmartMedicalGuide.Core.Features.Labs.Queries.Results;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Labs
{
    public partial class LabProfile
    {
        public void GetSingleLabResponseMapping()
        {
            CreateMap<Lab, GetSingleLabResponse>()
                .ForMember(dest => dest.LabName, opt => opt.MapFrom(src => src.User != null ? src.User.FullName : null))
                .ForMember(dest => dest.LabEmail, opt => opt.MapFrom(src => src.User != null ? src.User.Email : null));
        }
    }
}