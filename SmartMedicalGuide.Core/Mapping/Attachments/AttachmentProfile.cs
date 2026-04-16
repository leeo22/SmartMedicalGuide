using AutoMapper;

namespace SmartMedicalGuide.Core.Mapping.Attachments
{
    public partial class AttachmentProfile : Profile
    {
        public AttachmentProfile()
        {
            AddAttachmentCommandMapping();
            EditAttachmentCommandMapping();
            GetAttachmentByIDMapping();
            GetAttachmentListMapping();
        }
    }
}