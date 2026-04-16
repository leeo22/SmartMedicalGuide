using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.MedicalReports.Queries.Models;
using SmartMedicalGuide.Core.Features.MedicalReports.Queries.Results;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.MedicalReports.Queries.Handlers
{
    public class MedicalReportQueryHandler : ResponseHandler,
        IRequestHandler<GetMedicalReportListQuery, Response<List<GetMedicalReportListResponse>>>,
        IRequestHandler<GetMedicalReportByIDQuery, Response<GetSingleMedicalReportResponse>>
    {
        private readonly IMedicalReportServices _medicalReportServices;
        private readonly IMapper _mapper;

        public MedicalReportQueryHandler(IMedicalReportServices medicalReportServices, IMapper mapper)
        {
            _medicalReportServices = medicalReportServices;
            _mapper = mapper;
        }

        public async Task<Response<List<GetMedicalReportListResponse>>> Handle(GetMedicalReportListQuery request, CancellationToken cancellationToken)
        {
            var resultList = await _medicalReportServices.GetListAsync();
            if (request.PatientId.HasValue)
                resultList = resultList.Where(m => m.PatientId == request.PatientId.Value).ToList();
            if (request.DoctorId.HasValue)
                resultList = resultList.Where(m => m.DoctorId == request.DoctorId.Value).ToList();
            if (request.LabId.HasValue)
                resultList = resultList.Where(m => m.LabId == request.LabId.Value).ToList();
            var resultListMapper = _mapper.Map<List<GetMedicalReportListResponse>>(resultList);
            return Success(resultListMapper);
        }

        public async Task<Response<GetSingleMedicalReportResponse>> Handle(GetMedicalReportByIDQuery request, CancellationToken cancellationToken)
        {
            var result = await _medicalReportServices.GetByIDAsync(request.Id);
            if (result == null) return NotFound<GetSingleMedicalReportResponse>("No medical report found");
            var result1 = _mapper.Map<GetSingleMedicalReportResponse>(result);
            return Success(result1);
        }
    }
}