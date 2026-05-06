using AutoMapper;

namespace SmartMedicalGuide.Core.Mapping.Reviews
{
    public partial class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            AddReviewCommandMapping();
            EditReviewCommandMapping();
            GetReviewListResponseMapping();
            GetSingleReviewResponseMapping();
        }
    }
}