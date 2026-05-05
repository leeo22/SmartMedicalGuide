using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Clinics.Commands.Models;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Clinics.Commands.Handlers
{
    public class ClinicCommandHandler : ResponseHandler,
        IRequestHandler<AddClinicCommand, Response<string>>,
        IRequestHandler<EditClinicCommand, Response<string>>,
        IRequestHandler<DeleteClinicCommand, Response<string>>
    {
        private readonly IClinicServices _clinicServices;
        private readonly IMapper _mapper;

        public ClinicCommandHandler(IClinicServices clinicServices, IMapper mapper)
        {
            _clinicServices = clinicServices;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(AddClinicCommand request, CancellationToken cancellationToken)
        {
            var clinic = _mapper.Map<Clinic>(request);
            var result = await _clinicServices.AddAsync(clinic);

            if (result != "Success")
                return BadRequest<string>(result);

            return Created("Clinic added successfully");
        }

        public async Task<Response<string>> Handle(EditClinicCommand request, CancellationToken cancellationToken)
        {
            var clinic = _mapper.Map<Clinic>(request);
            var result = await _clinicServices.EditAsync(clinic);

            if (result == "Clinic not found")
                return NotFound<string>("Clinic not found");
            if (result != "Success")
                return BadRequest<string>(result);

            return Success("Clinic edited successfully");
        }

        public async Task<Response<string>> Handle(DeleteClinicCommand request, CancellationToken cancellationToken)
        {
            var clinic = await _clinicServices.GetByIDAsync(request.Id);
            if (clinic == null)
                return NotFound<string>("Clinic not found");

            var result = await _clinicServices.DeleteAsync(clinic);
            return result == "Success" ? Deleted<string>("Clinic deleted successfully") : BadRequest<string>(result);
        }
    }
}