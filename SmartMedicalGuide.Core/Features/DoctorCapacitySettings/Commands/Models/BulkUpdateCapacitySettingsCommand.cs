using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Features.DoctorCapacitySettings.Commands.Models
{
    public class BulkUpdateCapacitySettingsCommand : IRequest<Response<bool>>
    {
        public List<DoctorCapacitySetting> Settings { get; set; }
    }
}