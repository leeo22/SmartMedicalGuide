using SmartMedicalGuide.Core.Features.Reviews.Commands.Models;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Reviews
{
    public partial class ReviewProfile
    {
        public void EditReviewCommandMapping()
        {
            CreateMap<EditReviewCommand, Review>()
                .ForMember(dest => dest.ReviewId, opt => opt.MapFrom(src => src.ReviewId))
                .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.Rating))
                .ForMember(dest => dest.Comment, opt => opt.MapFrom(src => src.Comment));
        }
    }
}