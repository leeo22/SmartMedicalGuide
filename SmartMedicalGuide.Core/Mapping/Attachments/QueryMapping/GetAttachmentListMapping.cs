using SmartMedicalGuide.Core.Features.Attachments.Queries.Results;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Attachments
{
    public partial class AttachmentProfile
    {
        public void GetAttachmentListResponseMapping()
        {
            CreateMap<Attachment, GetAttachmentListResponse>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User != null ? src.User.UserName : null));
        }
    }
}