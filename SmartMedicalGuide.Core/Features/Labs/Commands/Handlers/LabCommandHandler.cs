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
                                       IRequestHandler<DeleteLabCommand, Response<string>>
    {
        #region Fields
        private readonly ILabServices _labServices;
        private readonly IMapper _mapper;
        #endregion
        #region Constructors
        public LabCommandHandler(ILabServices labServices, IMapper mapper)
        {
            _labServices = labServices;
            _mapper = mapper;
        }
        #endregion
        #region Handels Functions

        public async Task<Response<string>> Handle(AddLabCommand request, CancellationToken cancellationToken)
        {
            // mapping between request and user
            var labMapper = _mapper.Map<Lab>(request);
            //add
            var result = await _labServices.AddAsync(labMapper);
            //return response
            if (result == "Success") return Created("Added Sussessfully");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditLabCommand request, CancellationToken cancellationToken)
        {
            var lab = await _labServices.GetLabByIdAsync(request.LabId);
            if (lab == null) return NotFound<string>("user is not found");
            var labMapper = _mapper.Map<Lab>(request);
            var result = await _labServices.EditAsync(labMapper);
            if (result == "Success") return Success("Edited Sussessfully");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteLabCommand request, CancellationToken cancellationToken)
        {
            var lab = await _labServices.GetLabByIdAsync(request.Id);
            if (lab == null) return NotFound<string>("user is not found");
            var result = await _labServices.DeleteAsync(lab);
            if (result == "Success") return Deleted<string>($"Deleted Sussessfully {request.Id}");
            else return BadRequest<string>();
        }
        #endregion

    }

}
