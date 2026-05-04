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
        IRequestHandler<DeletePatientCommand, Response<string>>,
        IRequestHandler<UpdatePatientProfileCommand, Response<string>>
    {
        private readonly IPatientServices _patientServices;
        private readonly IMapper _mapper;

        public PatientCommandHandler(IPatientServices patientServices, IMapper mapper)
        {
            _patientServices = patientServices;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(AddPatientCommand request, CancellationToken cancellationToken)
        {
            var patient = _mapper.Map<Patient>(request);
            var result = await _patientServices.AddAsync(patient);

            if (result == "User is already registered as a patient")
                return BadRequest<string>("User is already registered as a patient");
            if (result != "Success")
                return BadRequest<string>("Failed to add patient");

            return Created("Patient added successfully");
        }

        public async Task<Response<string>> Handle(EditPatientCommand request, CancellationToken cancellationToken)
        {
            var patient = _mapper.Map<Patient>(request);
            var result = await _patientServices.EditAsync(patient);

            if (result == "Patient not found")
                return NotFound<string>("Patient not found");
            if (result != "Success")
                return BadRequest<string>("Failed to edit patient");

            return Success("Patient edited successfully");
        }

        public async Task<Response<string>> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
        {
            var patient = await _patientServices.GetByIDAsync(request.Id);
            if (patient == null)
                return NotFound<string>("Patient not found");

            var result = await _patientServices.DeleteAsync(patient);
            return result == "Success" ? Deleted<string>("Patient deleted successfully") : BadRequest<string>("Failed to delete patient");
        }

        public async Task<Response<string>> Handle(UpdatePatientProfileCommand request, CancellationToken cancellationToken)
        {
            var result = await _patientServices.UpdatePatientProfileAsync(
                request.PatientId, request.Gender, request.DateOfBirth, request.Address);

            if (result == "Patient not found")
                return NotFound<string>("Patient not found");
            if (result != "Success")
                return BadRequest<string>("Failed to update profile");

            return Success("Profile updated successfully");
        }
    }
}