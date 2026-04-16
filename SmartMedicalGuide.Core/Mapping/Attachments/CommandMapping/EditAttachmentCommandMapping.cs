using SmartMedicalGuide.Core.Features.Attachments.Commands.Models;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Attachments
{
    public partial class AttachmentProfile
    {
        public void EditAttachmentCommandMapping()
        {
            CreateMap<EditAttachmentCommand, Attachment>()
                .ForMember(dest => dest.AttachmentId, opt => opt.MapFrom(src => src.AttachmentId))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.FilePath, opt => opt.MapFrom(src => src.FilePath))
                .ForMember(dest => dest.UploadedAt, opt => opt.MapFrom(src => src.UploadedAt));
        }
    }
}