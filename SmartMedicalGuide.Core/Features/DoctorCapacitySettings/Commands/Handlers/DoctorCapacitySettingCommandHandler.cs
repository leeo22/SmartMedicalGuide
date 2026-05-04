using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.DoctorCapacitySettings.Commands.Models;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.DoctorCapacitySettings.Commands.Handlers
{
    public class DoctorCapacitySettingCommandHandler : ResponseHandler,
        IRequestHandler<AddDoctorCapacitySettingCommand, Response<string>>,
        IRequestHandler<EditDoctorCapacitySettingCommand, Response<string>>,
        IRequestHandler<DeleteDoctorCapacitySettingCommand, Response<string>>,
        IRequestHandler<DecrementDailyCapacityCommand, Response<bool>>,
        IRequestHandler<BulkUpdateCapacitySettingsCommand, Response<bool>>
    {
        #region Fields
        private readonly IDoctorCapacitySettingServices _services;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public DoctorCapacitySettingCommandHandler(IDoctorCapacitySettingServices services, IMapper mapper)
        {
            _services = services;
            _mapper = mapper;
        }
        #endregion

        #region Handlers
        public async Task<Response<string>> Handle(AddDoctorCapacitySettingCommand request, CancellationToken cancellationToken)
        {
            var existing = await _services.GetByDoctorIdAsync(request.DoctorId);
            if (existing != null)
                return BadRequest<string>("Capacity settings already exist for this doctor");

            var setting = _mapper.Map<DoctorCapacitySetting>(request);
            var result = await _services.AddAsync(setting);
            return result == "Success" ? Created("Capacity setting added successfully") : BadRequest<string>("Failed to add");
        }

        public async Task<Response<string>> Handle(EditDoctorCapacitySettingCommand request, CancellationToken cancellationToken)
        {
            var setting = await _services.GetByIDAsync(request.Id);
            if (setting == null)
                return NotFound<string>("Setting not found");

            var updatedSetting = _mapper.Map(request, setting);
            var result = await _services.EditAsync(updatedSetting);
            return result == "Success" ? Success("Capacity setting updated successfully") : BadRequest<string>("Failed to update");
        }

        public async Task<Response<string>> Handle(DeleteDoctorCapacitySettingCommand request, CancellationToken cancellationToken)
        {
            var setting = await _services.GetByIDAsync(request.Id);
            if (setting == null)
                return NotFound<string>("Setting not found");

            var result = await _services.DeleteAsync(setting);
            return result == "Success" ? Deleted<string>("Capacity setting deleted successfully") : BadRequest<string>("Failed to delete");
        }

        public async Task<Response<bool>> Handle(DecrementDailyCapacityCommand request, CancellationToken cancellationToken)
        {
            var result = await _services.DecrementDailyCapacityAsync(request.DoctorId);
            return result ? Success(true) : BadRequest<bool>("Failed to decrement capacity");
        }

        public async Task<Response<bool>> Handle(BulkUpdateCapacitySettingsCommand request, CancellationToken cancellationToken)
        {
            var result = await _services.BulkUpdateAsync(request.Settings);
            return result ? Success(true) : BadRequest<bool>("Bulk update failed");
        }
        #endregion
    }
}