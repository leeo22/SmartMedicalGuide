using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Patients.Commands.Models;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Patients.Commands.Handlers
{
    public class PatientCommandHandler : ResponseHandler,
                                       IRequestHandler<AddPatientCommand, Response<string>>,
                                       IRequestHandler<EditPatientCommand, Response<string>>,
                                       IRequestHandler<DeletePatientCommand, Response<string>>

    {
        #region Fields
        private readonly IPatientServices _patientServices;
        private readonly IMapper _mapper;

        #endregion


        #region Constructors
        public PatientCommandHandler(IPatientServices patientServices, IMapper mapper)
        {
            _patientServices = patientServices;
            _mapper = mapper;
        }
        #endregion

        #region Handle Functions
        public async Task<Response<string>> Handle(AddPatientCommand request, CancellationToken cancellationToken)
        {
            // mapping between request and patient
            var patientMapper = _mapper.Map<Patient>(request);
            //add
            var result = await _patientServices.AddAsync(patientMapper);
            //return response
            if (result == "Success") return Created("Added Sussessfully");
            else return BadRequest<string>();

        }

        public async Task<Response<string>> Handle(EditPatientCommand request, CancellationToken cancellationToken)
        {
            var Patient = await _patientServices.GetPatientByIdAsync(request.Id);
            if (Patient == null) return NotFound<string>("Patient is not found");
            var patientMapper = _mapper.Map<Patient>(request);
            var result = await _patientServices.EditAsync(patientMapper);
            if (result == "Success") return Success("Edited Sussessfully");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
        {
            var patient = await _patientServices.GetPatientByIdAsync(request.Id);
            if (patient == null) return NotFound<string>("Patient is not found");
            var result = await _patientServices.DeleteAsync(patient);
            if (result == "Success") return Deleted<string>($"Deleted Sussessfully {request.Id}");
            else return BadRequest<string>();

        }
        #endregion

    }
}
