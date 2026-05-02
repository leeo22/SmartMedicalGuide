using SmartMedicalGuide.Core.Features.ChatParticipants.Queries.Results;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.ChatParticipants
{
    public partial class ChatParticipantsProfile
    {
        public void GetUserChatsMapping()
        {
            CreateMap<ChatParticipant, UserChatResponse>()
                .ForMember(dest => dest.ChatId, opt => opt.MapFrom(src => src.ChatId))
                .ForMember(dest => dest.JoinedAt, opt => opt.MapFrom(src => src.JoinedAt))
                .ForMember(dest => dest.LastSeenAt, opt => opt.MapFrom(src => src.LastSeenAt))
                .ForMember(dest => dest.IsAdmin, opt => opt.MapFrom(src => src.IsAdmin))
                .ForMember(dest => dest.ChatName, opt => opt.MapFrom(src => src.Chat != null ? src.Chat.ChatName : null))
                .ForMember(dest => dest.IsGroup, opt => opt.MapFrom(src => src.Chat != null ? src.Chat.IsGroup : false))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.Chat != null ? src.Chat.IsActive : false))
                .ForMember(dest => dest.LastMessage, opt => opt.MapFrom(src => src.Chat != null ? src.Chat.LastMessage : null))
                .ForMember(dest => dest.LastMessageAt, opt => opt.MapFrom(src => src.Chat != null ? src.Chat.LastMessageAt : null));
        }
    }
}