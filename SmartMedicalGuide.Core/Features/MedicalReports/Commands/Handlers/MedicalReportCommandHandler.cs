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
        IRequestHandler<DeleteMedicalReportCommand, Response<string>>
    {
        private readonly IMedicalReportServices _medicalReportServices;
        private readonly IMapper _mapper;

        public MedicalReportCommandHandler(IMedicalReportServices medicalReportServices, IMapper mapper)
        {
            _medicalReportServices = medicalReportServices;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(AddMedicalReportCommand request, CancellationToken cancellationToken)
        {
            var resultMapper = _mapper.Map<MedicalReport>(request);
            var result = await _medicalReportServices.AddAsync(resultMapper);
            return result == "Success" ? Created("Medical report added successfully") : BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditMedicalReportCommand request, CancellationToken cancellationToken)
        {
            var result = await _medicalReportServices.GetByIDAsync(request.ReportId);
            if (result == null) return NotFound<string>("Medical report not found");
            var resultMapper = _mapper.Map<MedicalReport>(request);
            var result1 = await _medicalReportServices.EditAsync(resultMapper);
            return result1 == "Success" ? Success("Medical report edited successfully") : BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteMedicalReportCommand request, CancellationToken cancellationToken)
        {
            var result = await _medicalReportServices.GetByIDAsync(request.Id);
            if (result == null) return NotFound<string>("Medical report not found");
            var result1 = await _medicalReportServices.DeleteAsync(result);
            return result1 == "Success" ? Deleted<string>($"Medical report deleted successfully: {request.Id}") : BadRequest<string>();
        }
    }
}