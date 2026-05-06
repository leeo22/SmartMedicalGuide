using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.LabServices.Commands.Models;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.LabServices.Commands.Handlers
{
    public class LabServiceCommandHandler : ResponseHandler,
        IRequestHandler<AddLabServiceCommand, Response<string>>,
        IRequestHandler<EditLabServiceCommand, Response<string>>,
        IRequestHandler<DeleteLabServiceCommand, Response<string>>
    {
        private readonly ILabServiceServices _serviceServices;
        private readonly IMapper _mapper;

        public LabServiceCommandHandler(ILabServiceServices serviceServices, IMapper mapper)
        {
            _serviceServices = serviceServices;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(AddLabServiceCommand request, CancellationToken cancellationToken)
        {
            var service = _mapper.Map<LabService>(request);
            var result = await _serviceServices.AddAsync(service);

            if (result != "Success")
                return BadRequest<string>(result);

            return Created("Lab service added successfully");
        }

        public async Task<Response<string>> Handle(EditLabServiceCommand request, CancellationToken cancellationToken)
        {
            var service = _mapper.Map<LabService>(request);
            var result = await _serviceServices.EditAsync(service);

            if (result == "Service not found")
                return NotFound<string>("Service not found");
            if (result != "Success")
                return BadRequest<string>(result);

            return Success("Lab service edited successfully");
        }

        public async Task<Response<string>> Handle(DeleteLabServiceCommand request, CancellationToken cancellationToken)
        {
            var service = await _serviceServices.GetByIDAsync(request.Id);
            if (service == null)
                return NotFound<string>("Service not found");

            var result = await _serviceServices.DeleteAsync(service);
            return result == "Success" ? Deleted<string>("Lab service deleted successfully") : BadRequest<string>(result);
        }
    }
}