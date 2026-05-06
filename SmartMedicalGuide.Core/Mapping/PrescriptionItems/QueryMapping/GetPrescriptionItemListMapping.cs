using SmartMedicalGuide.Core.Features.PrescriptionItems.Queries.Results;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.PrescriptionItems
{
    public partial class PrescriptionItemProfile
    {
        public void GetPrescriptionItemListResponseMapping()
        {
            CreateMap<PrescriptionItem, GetPrescriptionItemListResponse>();
        }
    }
}