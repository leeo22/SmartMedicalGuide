using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.AppointmentHistories.Commands.Models;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.AppointmentHistories.Commands.Handlers
{
    public class AppointmentHistoryCommandHandler : ResponseHandler,
        IRequestHandler<AddAppointmentHistoryCommand, Response<string>>,
        IRequestHandler<EditAppointmentHistoryCommand, Response<string>>,
        IRequestHandler<DeleteAppointmentHistoryCommand, Response<string>>
    {
        private readonly IAppointmentHistoryServices _appointmentHistoryServices;
        private readonly IMapper _mapper;

        public AppointmentHistoryCommandHandler(IAppointmentHistoryServices appointmentHistoryServices, IMapper mapper)
        {
            _appointmentHistoryServices = appointmentHistoryServices;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(AddAppointmentHistoryCommand request, CancellationToken cancellationToken)
        {
            var resultMapper = _mapper.Map<AppointmentHistory>(request);
            var result = await _appointmentHistoryServices.AddAsync(resultMapper);
            return result == "Success" ? Created("Appointment history added successfully") : BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditAppointmentHistoryCommand request, CancellationToken cancellationToken)
        {
            var result = await _appointmentHistoryServices.GetByIDAsync(request.HistoryId);
            if (result == null) return NotFound<string>("Appointment history not found");
            var resultMapper = _mapper.Map<AppointmentHistory>(request);
            var result1 = await _appointmentHistoryServices.EditAsync(resultMapper);
            return result1 == "Success" ? Success("Appointment history edited successfully") : BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteAppointmentHistoryCommand request, CancellationToken cancellationToken)
        {
            var result = await _appointmentHistoryServices.GetByIDAsync(request.Id);
            if (result == null) return NotFound<string>("Appointment history not found");
            var result1 = await _appointmentHistoryServices.DeleteAsync(result);
            return result1 == "Success" ? Deleted<string>($"Appointment history deleted successfully: {request.Id}") : BadRequest<string>();
        }
    }
}