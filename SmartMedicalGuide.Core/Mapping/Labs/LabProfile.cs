using AutoMapper;

namespace SmartMedicalGuide.Core.Mapping.Labs
{
    public partial class LabProfile : Profile
    {
        public LabProfile()
        {
            EditLabCommandMapping();
            AddLabCommandMapping();
            GetLabByIDMapping();
            GetLabListMapping();
        }
    }
}
