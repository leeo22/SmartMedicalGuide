using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Reports.Commands.Models;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Reports.Commands.Handlers
{
    public class ReportCommandHandler : ResponseHandler,
                                       IRequestHandler<AddReportCommand, Response<string>>,
                                       IRequestHandler<EditReportCommand, Response<string>>,
                                       IRequestHandler<DeleteReportCommand, Response<string>>
    {
        #region Fields
        private readonly IReportServices _reportServices;
        private readonly IMapper _mapper;
        #endregion
        #region Constructors
        public ReportCommandHandler(IReportServices reportServices, IMapper mapper)
        {
            _reportServices = reportServices;
            _mapper = mapper;
        }

        #endregion
        #region Handels Functions

        public async Task<Response<string>> Handle(DeleteReportCommand request, CancellationToken cancellationToken)
        {
            var result = await _reportServices.GetByIDAsync(request.Id);
            if (result == null) return NotFound<string>("user is not found");
            var result1 = await _reportServices.DeleteAsync(result);
            if (result1 == "Success") return Deleted<string>($"Deleted Sussessfully {request.Id}");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditReportCommand request, CancellationToken cancellationToken)
        {
            var result = await _reportServices.GetByIDAsync(request.ReportId);
            if (result == null) return NotFound<string>("user is not found");
            var resultMapper = _mapper.Map<Report>(request);
            var result1 = await _reportServices.EditAsync(resultMapper);
            if (result1 == "Success") return Success("Edited Sussessfully");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(AddReportCommand request, CancellationToken cancellationToken)
        {
            // mapping between request and user
            var resultMapper = _mapper.Map<Report>(request);
            //add
            var result = await _reportServices.AddAsync(resultMapper);
            //return response
            if (result == "Success") return Created("Added Sussessfully");
            else return BadRequest<string>();


        }
        #endregion
    }
}
