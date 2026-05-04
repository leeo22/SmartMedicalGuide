using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.DoctorSchedules.Commands.Models;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.DoctorSchedules.Commands.Handlers
{
    public class DoctorScheduleCommandHandler : ResponseHandler,
        IRequestHandler<AddDoctorScheduleCommand, Response<string>>,
        IRequestHandler<EditDoctorScheduleCommand, Response<string>>,
        IRequestHandler<DeleteDoctorScheduleCommand, Response<string>>
    {
        private readonly IDoctorScheduleServices _scheduleServices;
        private readonly IMapper _mapper;

        public DoctorScheduleCommandHandler(IDoctorScheduleServices scheduleServices, IMapper mapper)
        {
            _scheduleServices = scheduleServices;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(AddDoctorScheduleCommand request, CancellationToken cancellationToken)
        {
            var schedule = _mapper.Map<DoctorSchedule>(request);
            var result = await _scheduleServices.AddAsync(schedule);

            if (result == "Schedule already exists for this doctor on this day")
                return BadRequest<string>("Schedule already exists for this doctor on this day");
            if (result != "Success")
                return BadRequest<string>(result);

            return Created("Doctor schedule added successfully");
        }

        public async Task<Response<string>> Handle(EditDoctorScheduleCommand request, CancellationToken cancellationToken)
        {
            var schedule = _mapper.Map<DoctorSchedule>(request);
            var result = await _scheduleServices.EditAsync(schedule);

            if (result == "Schedule not found")
                return NotFound<string>("Schedule not found");
            if (result != "Success")
                return BadRequest<string>(result);

            return Success("Doctor schedule edited successfully");
        }

        public async Task<Response<string>> Handle(DeleteDoctorScheduleCommand request, CancellationToken cancellationToken)
        {
            var schedule = await _scheduleServices.GetByIDAsync(request.Id);
            if (schedule == null)
                return NotFound<string>("Schedule not found");

            var result = await _scheduleServices.DeleteAsync(schedule);
            return result == "Success" ? Deleted<string>("Doctor schedule deleted successfully") : BadRequest<string>(result);
        }
    }
}