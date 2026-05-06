using SmartMedicalGuide.Core.Features.Attachments.Commands.Models;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Attachments
{
    public partial class AttachmentProfile
    {
        public void AddAttachmentCommandMapping()
        {
            CreateMap<AddAttachmentCommand, Attachment>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.RelatedEntityType, opt => opt.MapFrom(src => src.RelatedEntityType))
                .ForMember(dest => dest.RelatedEntityId, opt => opt.MapFrom(src => src.RelatedEntityId))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.FilePath, opt => opt.Ignore())
                .ForMember(dest => dest.FileName, opt => opt.Ignore())
                .ForMember(dest => dest.FileSize, opt => opt.Ignore())
                .ForMember(dest => dest.ContentType, opt => opt.Ignore());
        }
    }
}