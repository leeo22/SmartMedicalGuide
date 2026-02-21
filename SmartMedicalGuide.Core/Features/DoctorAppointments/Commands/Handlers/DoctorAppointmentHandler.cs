using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.DoctorAppointments.Commands.Models;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.DoctorAppointments.Commands.Handlers
{
    public class DoctorAppointmentHandler : ResponseHandler,
                                            IRequestHandler<AddDoctorAppointmentCommand, Response<string>>
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
            var doctorAppoMapper = _mapper.Map<DoctorAppointment>(request);
            var result = await _doctorAppointmentServices.AddAsync(doctorAppoMapper);
            if (result == "Success") return Created("Added Sussessfully");
            else return BadRequest<string>();
        }
        #endregion

    }
}
