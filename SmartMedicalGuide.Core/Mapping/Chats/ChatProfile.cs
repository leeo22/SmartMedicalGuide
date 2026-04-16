using AutoMapper;

namespace SmartMedicalGuide.Core.Mapping.Chats
{
    public partial class ChatProfile : Profile
    {
        public ChatProfile()
        {
            AddChatCommandMapping();
            EditChatCommandMapping();
            GetChatByIDMapping();
            GetChatListMapping();
        }
    }
}