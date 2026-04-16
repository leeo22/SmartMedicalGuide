using SmartMedicalGuide.Core.Features.PrescriptionItems.Commands.Models;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.PrescriptionItems
{
    public partial class PrescriptionItemProfile
    {
        public void AddPrescriptionItemCommandMapping()
        {
            CreateMap<AddPrescriptionItemCommand, PrescriptionItem>()
                .ForMember(dest => dest.PrescriptionId, opt => opt.MapFrom(src => src.PrescriptionId))
                .ForMember(dest => dest.MedicineName, opt => opt.MapFrom(src => src.MedicineName))
                .ForMember(dest => dest.Dosage, opt => opt.MapFrom(src => src.Dosage))
                .ForMember(dest => dest.Duration, opt => opt.MapFrom(src => src.Duration));
        }
    }
}