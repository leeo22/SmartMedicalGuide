using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.DoctorAppointments.Commands.Models;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.DoctorAppointments.Commands.Handlers
{
    public class DoctorAppointmentHandler : ResponseHandler,
                                            IRequestHandler<AddDoctorAppointmentCommand, Response<string>>,
                                            IRequestHandler<EditDoctorAppointmentCommand, Response<string>>,
                                            IRequestHandler<DeleteDoctorAppointmentCommand, Response<string>>
    {
        #region Fields
        private readonly IMapper _mapper;
        private readonly IDoctorAppointmentServices _doctorAppointmentServices;
        #endregion
        #region Constructors
        public DoctorAppointmentHandler(IMapper mapper,
                                        IDoctorAppointmentServices doctorAppointmentServices)
        {
            _mapper = mapper;
            _doctorAppointmentServices = doctorAppointmentServices;
        }
        #endregion
        #region Handels Functions
        public async Task<Response<string>> Handle(AddDoctorAppointmentCommand request, CancellationToken cancellationToken)
        {
            var doctorAppointmentMapper = _mapper.Map<DoctorAppointment>(request);
            var result = await _doctorAppointmentServices.AddAsync(doctorAppointmentMapper);
            if (result == "Success") return Created("Added Sussessfully");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditDoctorAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointment = await _doctorAppointmentServices.GetDoctorAppointmentByIDAsync(request.DoctorId);
            if (appointment == null) return NotFound<string>("user is not found");
            var doctorAppointmentMapper = _mapper.Map<DoctorAppointment>(request);
            var result = await _doctorAppointmentServices.EditAsync(doctorAppointmentMapper);
            if (result == "Success") return Success("Edited Sussessfully");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteDoctorAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointment = await _doctorAppointmentServices.GetDoctorAppointmentByIDAsync(request.Id);
            if (appointment == null) return NotFound<string>("user is not found");
            var result = await _doctorAppointmentServices.DeleteAsync(appointment);
            if (result == "Success") return Deleted<string>($"Deleted Sussessfully {request.Id}");
            else return BadRequest<string>();
        }
        #endregion

    }
}
