using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.DoctorCapacitySettings.Queries.Results;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Features.DoctorCapacitySettings.Queries.Models
{
    public class GetDoctorCapacitySettingListQuery : IRequest<Response<List<GetDoctorCapacitySettingListResponse>>>
    {
        // Optional filters
        public int? DoctorId { get; set; }
        public bool? IsActive { get; set; }
        public int? MinCapacity { get; set; }
        public ShiftType? ShiftType { get; set; }
        public BookingType? BookingType { get; set; }
    }
}