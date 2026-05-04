using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.DoctorAppointments.Commands.Models;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.DoctorAppointments.Commands.Handlers
{
    public class DoctorAppointmentCommandHandler : ResponseHandler,
        IRequestHandler<AddDoctorAppointmentCommand, Response<string>>,
        IRequestHandler<EditDoctorAppointmentCommand, Response<string>>,
        IRequestHandler<DeleteDoctorAppointmentCommand, Response<string>>
    {
        private readonly IDoctorAppointmentServices _appointmentServices;
        private readonly IMapper _mapper;

        public DoctorAppointmentCommandHandler(IDoctorAppointmentServices appointmentServices, IMapper mapper)
        {
            _appointmentServices = appointmentServices;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(AddDoctorAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointment = _mapper.Map<DoctorAppointment>(request);
            var result = await _appointmentServices.AddAsync(appointment);

            if (result != "Success")
                return BadRequest<string>("Failed to add appointment");

            return Created("Appointment added successfully");
        }

        public async Task<Response<string>> Handle(EditDoctorAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointment = _mapper.Map<DoctorAppointment>(request);
            var result = await _appointmentServices.EditAsync(appointment);

            if (result == "Appointment not found")
                return NotFound<string>("Appointment not found");
            if (result != "Success")
                return BadRequest<string>("Failed to edit appointment");

            return Success("Appointment edited successfully");
        }

        public async Task<Response<string>> Handle(DeleteDoctorAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointment = await _appointmentServices.GetByIDAsync(request.Id);
            if (appointment == null)
                return NotFound<string>("Appointment not found");

            var result = await _appointmentServices.DeleteAsync(appointment);
            return result == "Success" ? Deleted<string>("Appointment deleted successfully") : BadRequest<string>("Failed to delete appointment");
        }
        #region Additional Command Handlers
        public async Task<Response<string>> Handle(CancelAppointmentCommand request, CancellationToken cancellationToken)
        {
            var result = await _appointmentServices.CancelAppointmentAsync(
                request.AppointmentId, request.CancellationReason, request.RescheduledByUserId);

            if (result == "Appointment not found")
                return NotFound<string>("Appointment not found");
            if (result != "Success")
                return BadRequest<string>("Failed to cancel appointment");

            return Success("Appointment cancelled successfully");
        }

        public async Task<Response<string>> Handle(ConfirmAppointmentCommand request, CancellationToken cancellationToken)
        {
            var result = await _appointmentServices.ConfirmAppointmentAsync(request.AppointmentId);

            if (result == "Appointment not found")
                return NotFound<string>("Appointment not found");
            if (result != "Success")
                return BadRequest<string>("Failed to confirm appointment");

            return Success("Appointment confirmed successfully");
        }

        public async Task<Response<string>> Handle(CompleteAppointmentCommand request, CancellationToken cancellationToken)
        {
            var result = await _appointmentServices.CompleteAppointmentAsync(request.AppointmentId);

            if (result == "Appointment not found")
                return NotFound<string>("Appointment not found");
            if (result != "Success")
                return BadRequest<string>("Failed to complete appointment");

            return Success("Appointment completed successfully");
        }

        public async Task<Response<string>> Handle(RescheduleAppointmentCommand request, CancellationToken cancellationToken)
        {
            var result = await _appointmentServices.RescheduleAppointmentAsync(
                request.AppointmentId, request.NewAppointmentDate, request.Reason, request.RescheduledByUserId);

            if (result == "Appointment not found")
                return NotFound<string>("Appointment not found");
            if (result != "Success")
                return BadRequest<string>("Failed to reschedule appointment");

            return Success("Appointment rescheduled successfully");
        }
        #endregion
    }
}