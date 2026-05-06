using SmartMedicalGuide.Core.Features.Reviews.Queries.Results;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Reviews
{
    public partial class ReviewProfile
    {
        public void GetReviewListResponseMapping()
        {
            CreateMap<Review, GetReviewListResponse>()
                .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient != null && src.Patient.User != null ? src.Patient.User.FullName : null))
                .ForMember(dest => dest.PatientImageUrl, opt => opt.MapFrom(src => src.Patient != null && src.Patient.User != null ? src.Patient.User.ProfileImageUrl : null));
        }
    }
}