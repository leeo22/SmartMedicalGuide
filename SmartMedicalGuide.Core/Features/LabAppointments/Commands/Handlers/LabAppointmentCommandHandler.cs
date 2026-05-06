using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.LabAppointments.Commands.Models;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.LabAppointments.Commands.Handlers
{
    public class LabAppointmentCommandHandler : ResponseHandler,
        IRequestHandler<AddLabAppointmentCommand, Response<string>>,
        IRequestHandler<EditLabAppointmentCommand, Response<string>>,
        IRequestHandler<DeleteLabAppointmentCommand, Response<string>>,
        IRequestHandler<CancelLabAppointmentCommand, Response<string>>,
        IRequestHandler<ConfirmLabAppointmentCommand, Response<string>>,
        IRequestHandler<CompleteLabAppointmentCommand, Response<string>>
    {
        private readonly ILabAppointmentServices _appointmentServices;
        private readonly IMapper _mapper;

        public LabAppointmentCommandHandler(ILabAppointmentServices appointmentServices, IMapper mapper)
        {
            _appointmentServices = appointmentServices;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(AddLabAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointment = _mapper.Map<LabAppointment>(request);
            var result = await _appointmentServices.AddAsync(appointment);

            if (result != "Success")
                return BadRequest<string>(result);

            return Created("Lab appointment added successfully");
        }

        public async Task<Response<string>> Handle(EditLabAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointment = _mapper.Map<LabAppointment>(request);
            var result = await _appointmentServices.EditAsync(appointment);

            if (result == "Appointment not found")
                return NotFound<string>("Appointment not found");
            if (result != "Success")
                return BadRequest<string>(result);

            return Success("Lab appointment edited successfully");
        }

        public async Task<Response<string>> Handle(DeleteLabAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointment = await _appointmentServices.GetByIDAsync(request.Id);
            if (appointment == null)
                return NotFound<string>("Appointment not found");

            var result = await _appointmentServices.DeleteAsync(appointment);
            return result == "Success" ? Deleted<string>("Lab appointment deleted successfully") : BadRequest<string>(result);
        }

        public async Task<Response<string>> Handle(CancelLabAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointment = await _appointmentServices.GetByIDAsync(request.AppointmentId);
            if (appointment == null)
                return NotFound<string>("Appointment not found");

            appointment.Status = "Cancelled";
            appointment.CancellationReason = request.CancellationReason;
            appointment.RescheduledByUserId = request.RescheduledByUserId;

            var result = await _appointmentServices.EditAsync(appointment);
            return result == "Success" ? Success("Lab appointment cancelled successfully") : BadRequest<string>(result);
        }

        public async Task<Response<string>> Handle(ConfirmLabAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointment = await _appointmentServices.GetByIDAsync(request.AppointmentId);
            if (appointment == null)
                return NotFound<string>("Appointment not found");

            appointment.Status = "Confirmed";
            var result = await _appointmentServices.EditAsync(appointment);
            return result == "Success" ? Success("Lab appointment confirmed successfully") : BadRequest<string>(result);
        }

        public async Task<Response<string>> Handle(CompleteLabAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointment = await _appointmentServices.GetByIDAsync(request.AppointmentId);
            if (appointment == null)
                return NotFound<string>("Appointment not found");

            appointment.Status = "Completed";
            var result = await _appointmentServices.EditAsync(appointment);
            return result == "Success" ? Success("Lab appointment completed successfully") : BadRequest<string>(result);
        }
    }
}