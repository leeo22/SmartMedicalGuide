using AutoMapper;

namespace SmartMedicalGuide.Core.Mapping.PrescriptionItems
{
    public partial class PrescriptionItemProfile : Profile
    {
        public PrescriptionItemProfile()
        {
            AddPrescriptionItemCommandMapping();
            EditPrescriptionItemCommandMapping();
            GetPrescriptionItemByIDMapping();
            GetPrescriptionItemListMapping();
        }
    }
}