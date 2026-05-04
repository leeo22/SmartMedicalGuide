using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.DoctorCapacitySettings.Queries.Results;

namespace SmartMedicalGuide.Core.Features.DoctorCapacitySettings.Queries.Models
{
    public class GetDoctorCapacitySettingByIDQuery : IRequest<Response<GetSingleDoctorCapacitySettingResponse>>
    {
        public int Id { get; set; }
        public GetDoctorCapacitySettingByIDQuery(int id) => Id = id;
    }
}