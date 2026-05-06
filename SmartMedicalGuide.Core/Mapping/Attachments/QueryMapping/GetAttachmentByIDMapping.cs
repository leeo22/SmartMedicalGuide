using SmartMedicalGuide.Core.Features.Attachments.Queries.Results;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Attachments
{
    public partial class AttachmentProfile
    {
        public void GetSingleAttachmentResponseMapping()
        {
            CreateMap<Attachment, GetSingleAttachmentResponse>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User != null ? src.User.UserName : null))
                .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.User != null ? src.User.Email : null));
        }
    }
}