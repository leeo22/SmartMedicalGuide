using AutoMapper;

namespace SmartMedicalGuide.Core.Mapping.Prescriptions
{
    public partial class PrescriptionProfile : Profile
    {
        public PrescriptionProfile()
        {
            AddPrescriptionCommandMapping();
            EditPrescriptionCommandMapping();
            GetPrescriptionListResponseMapping();
            GetSinglePrescriptionResponseMapping();
            GetPrescriptionWithItemsResponseMapping();
        }
    }
}