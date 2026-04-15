using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Specializations.Commands.Models;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Specializations.Commands.Handlers
{
    public class SpecializationCommandHandler : ResponseHandler,
                                       IRequestHandler<AddSpecializationCommand, Response<string>>,
                                       IRequestHandler<EditSpecializationCommand, Response<string>>,
                                       IRequestHandler<DeleteSpecializationCommand, Response<string>>
    {

        #region Fields
        private readonly ISpecializationServices _specializationServices;
        private readonly IMapper _mapper;
        #endregion
        #region Constructors
        public SpecializationCommandHandler(ISpecializationServices specializationServices, IMapper mapper)
        {
            _specializationServices = specializationServices;
            _mapper = mapper;
        }

        #endregion
        #region Handels Functions

        public async Task<Response<string>> Handle(DeleteSpecializationCommand request, CancellationToken cancellationToken)
        {
            var result = await _specializationServices.GetByIDAsync(request.Id);
            if (result == null) return NotFound<string>("user is not found");
            var result1 = await _specializationServices.DeleteAsync(result);
            if (result1 == "Success") return Deleted<string>($"Deleted Sussessfully {request.Id}");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditSpecializationCommand request, CancellationToken cancellationToken)
        {
            var result = await _specializationServices.GetByIDAsync(request.SpecializationId);
            if (result == null) return NotFound<string>("user is not found");
            var resultMapper = _mapper.Map<Specialization>(request);
            var result1 = await _specializationServices.EditAsync(resultMapper);
            if (result1 == "Success") return Success("Edited Sussessfully");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(AddSpecializationCommand request, CancellationToken cancellationToken)
        {
            // mapping between request and user
            var resultMapper = _mapper.Map<Specialization>(request);
            //add
            var result = await _specializationServices.AddAsync(resultMapper);
            //return response
            if (result == "Success") return Created("Added Sussessfully");
            else return BadRequest<string>();


        }
        #endregion
    }

}