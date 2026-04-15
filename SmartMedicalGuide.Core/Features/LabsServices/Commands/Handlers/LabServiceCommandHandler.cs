using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.LabsServices.Commands.Models;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.LabsServices.Commands.Handlers
{
    public class LabServiceCommandHandler : ResponseHandler,
                                       IRequestHandler<AddLabServiceCommand, Response<string>>,
                                       IRequestHandler<EditLabServiceCommand, Response<string>>,
                                       IRequestHandler<DeleteLabServiceCommand, Response<string>>
    {
        #region Fields
        private readonly ILabServiceServices _labServiceServices;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public LabServiceCommandHandler(ILabServiceServices labServiceServices, IMapper mapper)
        {
            _labServiceServices = labServiceServices;
            _mapper = mapper;
        }
        #endregion

        #region Handlers Functions
        public async Task<Response<string>> Handle(AddLabServiceCommand request, CancellationToken cancellationToken)
        {
            // التحقق من وجود المختبر
            //var labExists = await _labServiceServices.DoesLabExistAsync(request.LabId);
            //if (!labExists)
            //    return BadRequest<string>("Lab not found");

            var resultMapper = _mapper.Map<LabService>(request);
            var result = await _labServiceServices.AddAsync(resultMapper);

            if (result == "Success")
                return Created("Lab service added successfully");
            else
                return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditLabServiceCommand request, CancellationToken cancellationToken)
        {
            var result = await _labServiceServices.GetLabByIDAsync(request.ServiceId);
            if (result == null)
                return NotFound<string>("Lab service not found");

            var resultMapper = _mapper.Map<LabService>(request);
            var result1 = await _labServiceServices.EditAsync(resultMapper);

            if (result1 == "Success")
                return Success("Lab service edited successfully");
            else
                return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteLabServiceCommand request, CancellationToken cancellationToken)
        {
            var result = await _labServiceServices.GetLabByIDAsync(request.Id);
            if (result == null)
                return NotFound<string>("Lab service not found");

            var result1 = await _labServiceServices.DeleteAsync(result);

            if (result1 == "Success")
                return Deleted<string>($"Lab service deleted successfully: {request.Id}");
            else
                return BadRequest<string>();
        }
        #endregion
    }
}