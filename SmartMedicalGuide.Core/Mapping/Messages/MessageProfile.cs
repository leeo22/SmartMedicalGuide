using AutoMapper;

namespace SmartMedicalGuide.Core.Mapping.Messages
{
    public partial class MessageProfile : Profile
    {
        public MessageProfile()
        {
            AddMessageCommandMapping();
            EditMessageCommandMapping();
            GetMessageByIDMapping();
            GetMessageListMapping();
        }
    }
}