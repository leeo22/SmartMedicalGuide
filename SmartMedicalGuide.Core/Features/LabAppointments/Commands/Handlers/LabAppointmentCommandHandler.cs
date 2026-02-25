using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.DoctorAppointments.Commands.Models;
using SmartMedicalGuide.Core.Features.LabAppointments.Commands.Models;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Services.Abstracts;
using SmartMedicalGuide.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMedicalGuide.Core.Features.LabAppointments.Commands.Handlers
{
    public class LabAppointmentCommandHandler : ResponseHandler,
                                            IRequestHandler<AddLabAppointmentCommand, Response<string>>,
                                            IRequestHandler<EditLabAppointmentCommand, Response<string>>,
                                            IRequestHandler<DeleteLabAppointmentCommand, Response<string>>
    {

        #region Fields
        private readonly ILabAppointmentServices _labAppointmentServices;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public LabAppointmentCommandHandler(ILabAppointmentServices labAppointmentServices, IMapper mapper)
        {
            _labAppointmentServices = labAppointmentServices;
            _mapper = mapper;
        }
        #endregion





        #region Handels Functions

        public async Task<Response<string>> Handle(AddLabAppointmentCommand request, CancellationToken cancellationToken)
        {
            
            var labAppointmentMapper = _mapper.Map<LabAppointment>(request);
            //add
            var result = await _labAppointmentServices.AddAsync(labAppointmentMapper);
            //return response
            if (result == "Success") return Created("Added Sussessfully");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditLabAppointmentCommand request, CancellationToken cancellationToken)
        {
            var labAppointment = await _labAppointmentServices.GetLabAppointmentsByIDAsync(request.LabAppointmentId);
            if (labAppointment == null) return NotFound<string>("Clinic is not found");
            var labbAppointmentMapper = _mapper.Map<LabAppointment>(request);
            var result = await _labAppointmentServices.EditAsync(labbAppointmentMapper);
            if (result == "Success") return Success("Edited Sussessfully");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteLabAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointment = await _labAppointmentServices.GetLabAppointmentsByIDAsync(request.Id);
            if (appointment == null) return NotFound<string>("user is not found");
            var result = await _labAppointmentServices.DeleteAsync(appointment);
            if (result == "Success") return Deleted<string>($"Deleted Sussessfully {request.Id}");
            else return BadRequest<string>();
        }
        #endregion
    }
}
