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

        #region Handlers
        public async Task<Response<string>> Handle(AddSpecializationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var specialization = _mapper.Map<Specialization>(request);
                var result = await _specializationServices.AddAsync(specialization);

                if (result.StartsWith("Failed"))
                    return BadRequest<string>(result);
                if (result.Contains("already exists"))
                    return BadRequest<string>(result);

                return Created("Specialization added successfully");
            }
            catch (Exception ex)
            {
                return BadRequest<string>($"An error occurred: {ex.Message}");
            }
        }

        public async Task<Response<string>> Handle(EditSpecializationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var specialization = _mapper.Map<Specialization>(request);
                var result = await _specializationServices.EditAsync(specialization);

                if (result == "Specialization not found")
                    return NotFound<string>("Specialization not found");
                if (result.Contains("already exists"))
                    return BadRequest<string>(result);
                if (result.StartsWith("Failed"))
                    return BadRequest<string>(result);

                return Success("Specialization edited successfully");
            }
            catch (Exception ex)
            {
                return BadRequest<string>($"An error occurred: {ex.Message}");
            }
        }

        public async Task<Response<string>> Handle(DeleteSpecializationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var specialization = await _specializationServices.GetByIDAsync(request.Id);
                if (specialization == null)
                    return NotFound<string>("Specialization not found");

                var result = await _specializationServices.DeleteAsync(specialization);

                if (result.Contains("Cannot delete"))
                    return BadRequest<string>(result);
                if (result != "Success")
                    return BadRequest<string>(result);

                return Deleted<string>("Specialization deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest<string>($"An error occurred: {ex.Message}");
            }
        }
        #endregion
    }
}