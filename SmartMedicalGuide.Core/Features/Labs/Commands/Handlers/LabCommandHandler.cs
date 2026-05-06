using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Labs.Commands.Models;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Labs.Commands.Handlers
{
    public class LabCommandHandler : ResponseHandler,
        IRequestHandler<AddLabCommand, Response<string>>,
        IRequestHandler<EditLabCommand, Response<string>>,
        IRequestHandler<DeleteLabCommand, Response<string>>,
        IRequestHandler<UpdateLabVerificationStatusCommand, Response<string>>
    {
        private readonly ILabServices _labServices;
        private readonly IMapper _mapper;

        public LabCommandHandler(ILabServices labServices, IMapper mapper)
        {
            _labServices = labServices;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(AddLabCommand request, CancellationToken cancellationToken)
        {
            var lab = _mapper.Map<Lab>(request);
            var result = await _labServices.AddAsync(lab);

            if (result != "Success")
                return BadRequest<string>(result);

            return Created("Lab added successfully");
        }

        public async Task<Response<string>> Handle(EditLabCommand request, CancellationToken cancellationToken)
        {
            var lab = _mapper.Map<Lab>(request);
            var result = await _labServices.EditAsync(lab);

            if (result == "Lab not found")
                return NotFound<string>("Lab not found");
            if (result != "Success")
                return BadRequest<string>(result);

            return Success("Lab edited successfully");
        }

        public async Task<Response<string>> Handle(DeleteLabCommand request, CancellationToken cancellationToken)
        {
            var lab = await _labServices.GetByIDAsync(request.Id);
            if (lab == null)
                return NotFound<string>("Lab not found");

            var result = await _labServices.DeleteAsync(lab);
            return result == "Success" ? Deleted<string>("Lab deleted successfully") : BadRequest<string>(result);
        }

        public async Task<Response<string>> Handle(UpdateLabVerificationStatusCommand request, CancellationToken cancellationToken)
        {
            var lab = await _labServices.GetByIDAsync(request.LabId);
            if (lab == null)
                return NotFound<string>("Lab not found");

            lab.VerificationStatus = request.VerificationStatus;
            var result = await _labServices.EditAsync(lab);

            return result == "Success"
                ? Success($"Lab verification status updated to {request.VerificationStatus}")
                : BadRequest<string>("Failed to update verification status");
        }
    }
}