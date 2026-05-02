using AutoMapper;

namespace SmartMedicalGuide.Core.Mapping.ChatParticipants
{
    public partial class ChatParticipantsProfile : Profile
    {
        public ChatParticipantsProfile()
        {
            AddParticipantToChatCommandMapping();
            GetChatParticipantssMapping();
            GetUserChatsMapping();
        }
    }
}