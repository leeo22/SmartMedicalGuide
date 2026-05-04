using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.MedicalReports.Commands.Models;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.MedicalReports.Commands.Handlers
{
    public class MedicalReportCommandHandler : ResponseHandler,
        IRequestHandler<AddMedicalReportCommand, Response<string>>,
        IRequestHandler<EditMedicalReportCommand, Response<string>>,
        IRequestHandler<UploadReportFileCommand, Response<string>>,
        IRequestHandler<DeleteReportFileCommand, Response<string>>,
        IRequestHandler<UpdateReportFileCommand, Response<string>>
    {
        private readonly IMedicalReportServices _reportServices;
        private readonly IMapper _mapper;

        public MedicalReportCommandHandler(IMedicalReportServices reportServices, IMapper mapper)
        {
            _reportServices = reportServices;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(AddMedicalReportCommand request, CancellationToken cancellationToken)
        {
            var report = _mapper.Map<MedicalReport>(request);
            var result = await _reportServices.AddAsync(report);

            if (result != "Success")
                return BadRequest<string>(result);

            return Created("Medical report added successfully");
        }

        public async Task<Response<string>> Handle(EditMedicalReportCommand request, CancellationToken cancellationToken)
        {
            var report = _mapper.Map<MedicalReport>(request);
            var result = await _reportServices.EditAsync(report);

            if (result == "Report not found")
                return NotFound<string>("Report not found");
            if (result != "Success")
                return BadRequest<string>(result);

            return Success("Medical report edited successfully");
        }

        public async Task<Response<string>> Handle(UploadReportFileCommand request, CancellationToken cancellationToken)
        {
            var result = await _reportServices.UploadReportFileAsync(request.ReportId, request.File);

            if (result == "Report not found")
                return NotFound<string>("Report not found");
            if (result != "Success")
                return BadRequest<string>(result);

            return Success("File uploaded successfully");
        }

        public async Task<Response<string>> Handle(DeleteReportFileCommand request, CancellationToken cancellationToken)
        {
            var result = await _reportServices.DeleteReportFileAsync(request.ReportId);

            if (result == "Report not found")
                return NotFound<string>("Report not found");
            if (result != "Success")
                return BadRequest<string>(result);

            return Success("File deleted successfully");
        }

        public async Task<Response<string>> Handle(UpdateReportFileCommand request, CancellationToken cancellationToken)
        {
            var result = await _reportServices.UpdateReportFileAsync(request.ReportId, request.File);

            if (result == "Report not found")
                return NotFound<string>("Report not found");
            if (result != "Success")
                return BadRequest<string>(result);

            return Success("File updated successfully");
        }
    }
}