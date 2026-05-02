using SmartMedicalGuide.Core.Features.Chats.Queries.Results;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Chats
{
    public partial class ChatProfile
    {
        public void GetChatByIDMapping()
        {
            CreateMap<Chat, GetSingleChatResponse>()
                .ForMember(dest => dest.ChatId, opt => opt.MapFrom(src => src.ChatId))
                .ForMember(dest => dest.PatientId, opt => opt.MapFrom(src => src.PatientId))
                .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient != null && src.Patient.User != null ? src.Patient.User.FullName : null))
                .ForMember(dest => dest.PatientEmail, opt => opt.MapFrom(src => src.Patient != null && src.Patient.User != null ? src.Patient.User.Email : null))
                .ForMember(dest => dest.DoctorId, opt => opt.MapFrom(src => src.DoctorId))
                .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor != null && src.Doctor.User != null ? src.Doctor.User.FullName : null))
                .ForMember(dest => dest.DoctorEmail, opt => opt.MapFrom(src => src.Doctor != null && src.Doctor.User != null ? src.Doctor.User.Email : null))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.Messages, opt => opt.MapFrom(src => src.Messages != null ? src.Messages.Where(m => !m.IsDeleted) : null))
                .ForMember(dest => dest.ChatName, opt => opt.MapFrom(src => src.ChatName))
                .ForMember(dest => dest.IsGroup, opt => opt.MapFrom(src => src.IsGroup))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.LastMessage, opt => opt.MapFrom(src => src.LastMessage))
                .ForMember(dest => dest.LastMessageAt, opt => opt.MapFrom(src => src.LastMessageAt));
        }
    }
}