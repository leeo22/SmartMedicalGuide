using SmartMedicalGuide.Core.Features.Reviews.Commands.Models;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Reviews
{
    public partial class ReviewProfile
    {
        public void AddReviewCommandMapping()
        {
            CreateMap<AddReviewCommand, Review>()
                .ForMember(dest => dest.PatientId, opt => opt.MapFrom(src => src.PatientId))
                .ForMember(dest => dest.TargetType, opt => opt.MapFrom(src => src.TargetType))
                .ForMember(dest => dest.TargetId, opt => opt.MapFrom(src => src.TargetId))
                .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.Rating))
                .ForMember(dest => dest.Comment, opt => opt.MapFrom(src => src.Comment));
        }
    }
}