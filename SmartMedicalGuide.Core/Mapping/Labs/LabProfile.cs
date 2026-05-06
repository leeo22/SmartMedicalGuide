using AutoMapper;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SmartMedicalGuide.Core.Mapping.Labs
{
    public partial class LabProfile : Profile
    {
        public LabProfile()
        {
            AddLabCommandMapping();
            EditLabCommandMapping();
            GetLabListResponseMapping();
            GetSingleLabResponseMapping();
        }
    }
}