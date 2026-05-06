using AutoMapper;

namespace SmartMedicalGuide.Core.Mapping.LabServices
{
    public partial class LabServiceProfile : Profile
    {
        public LabServiceProfile()
        {
            AddLabServiceCommandMapping();
            EditLabServiceCommandMapping();
            GetLabServiceListResponseMapping();
            GetSingleLabServiceResponseMapping();
        }
    }
}