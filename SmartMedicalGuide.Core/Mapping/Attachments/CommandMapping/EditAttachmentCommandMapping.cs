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
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.RelatedEntityType, opt => opt.MapFrom(src => src.RelatedEntityType))
                .ForMember(dest => dest.RelatedEntityId, opt => opt.MapFrom(src => src.RelatedEntityId));
        }
    }
}