using SmartMedicalGuide.Core.Features.ChatParticipants.Commands.Models;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.ChatParticipants
{
    public partial class ChatParticipantsProfile
    {
        public void AddParticipantToChatCommandMapping()
        {
            CreateMap<AddParticipantToChatCommand, ChatParticipant>()
                .ForMember(dest => dest.ChatId, opt => opt.MapFrom(src => src.ChatId))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.IsAdmin, opt => opt.MapFrom(src => src.IsAdmin))
                .ForMember(dest => dest.JoinedAt, opt => opt.MapFrom(src => DateTime.UtcNow));
        }
    }
}