using SmartMedicalGuide.Core.Features.Prescriptions.Commands.Models;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Prescriptions
{
    public partial class PrescriptionProfile
    {
        public void EditPrescriptionCommandMapping()
        {
            CreateMap<EditPrescriptionCommand, Prescription>()
                .ForMember(dest => dest.PrescriptionId, opt => opt.MapFrom(src => src.PrescriptionId))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Notes, opt => opt.MapFrom(src => src.Notes))
                .ForMember(dest => dest.FollowUpDate, opt => opt.MapFrom(src => src.FollowUpDate))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));
        }
    }
}