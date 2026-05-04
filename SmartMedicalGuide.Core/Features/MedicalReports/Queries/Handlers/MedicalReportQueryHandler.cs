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
        IRequestHandler<GetMedicalReportByPatientIdQuery, Response<List<GetMedicalReportListResponse>>>,
        IRequestHandler<GetMedicalReportByDoctorIdQuery, Response<List<GetMedicalReportListResponse>>>,
        IRequestHandler<GetMedicalReportByReportTypeQuery, Response<List<GetMedicalReportListResponse>>>,
        IRequestHandler<GetMedicalReportByDateRangeQuery, Response<List<GetMedicalReportListResponse>>>,
        IRequestHandler<GetPatientMedicalHistoryQuery, Response<List<GetPatientMedicalHistoryResponse>>>,
        IRequestHandler<GetMedicalReportStatisticsQuery, Response<object>>,
        IRequestHandler<DownloadReportFileQuery, Response<(string filePath, string fileName, string contentType)>>
    {
        private readonly IMedicalReportServices _reportServices;
        private readonly IMapper _mapper;

        public MedicalReportQueryHandler(IMedicalReportServices reportServices, IMapper mapper)
        {
            _reportServices = reportServices;
            _mapper = mapper;
        }

        public async Task<Response<List<GetMedicalReportListResponse>>> Handle(GetMedicalReportListQuery request, CancellationToken cancellationToken)
        {
            var reports = await _reportServices.GetListAsync();
            var result = _mapper.Map<List<GetMedicalReportListResponse>>(reports);
            return Success(result);
        }

        public async Task<Response<List<GetMedicalReportListResponse>>> Handle(GetMedicalReportByPatientIdQuery request, CancellationToken cancellationToken)
        {
            var reports = await _reportServices.GetByPatientIdAsync(request.PatientId);
            var result = _mapper.Map<List<GetMedicalReportListResponse>>(reports);
            return Success(result);
        }

        public async Task<Response<List<GetMedicalReportListResponse>>> Handle(GetMedicalReportByDoctorIdQuery request, CancellationToken cancellationToken)
        {
            var reports = await _reportServices.GetByDoctorIdAsync(request.DoctorId);
            var result = _mapper.Map<List<GetMedicalReportListResponse>>(reports);
            return Success(result);
        }

        public async Task<Response<List<GetMedicalReportListResponse>>> Handle(GetMedicalReportByReportTypeQuery request, CancellationToken cancellationToken)
        {
            var reports = await _reportServices.GetByReportTypeAsync(request.ReportType);
            var result = _mapper.Map<List<GetMedicalReportListResponse>>(reports);
            return Success(result);
        }

        public async Task<Response<List<GetMedicalReportListResponse>>> Handle(GetMedicalReportByDateRangeQuery request, CancellationToken cancellationToken)
        {
            var reports = await _reportServices.GetByDateRangeAsync(request.FromDate, request.ToDate);
            var result = _mapper.Map<List<GetMedicalReportListResponse>>(reports);
            return Success(result);
        }

        public async Task<Response<List<GetPatientMedicalHistoryResponse>>> Handle(GetPatientMedicalHistoryQuery request, CancellationToken cancellationToken)
        {
            var history = await _reportServices.GetPatientMedicalHistoryAsync(request.PatientId);
            var result = _mapper.Map<List<GetPatientMedicalHistoryResponse>>(history);
            return Success(result);
        }

        public async Task<Response<object>> Handle(GetMedicalReportStatisticsQuery request, CancellationToken cancellationToken)
        {
            var statistics = await _reportServices.GetReportStatisticsAsync();
            return Success(statistics);
        }

        public async Task<Response<(string filePath, string fileName, string contentType)>> Handle(DownloadReportFileQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _reportServices.DownloadReportFileAsync(request.ReportId);
                return Success(result);
            }
            catch (Exception ex)
            {
                return BadRequest<(string filePath, string fileName, string contentType)>(ex.Message);
            }
        }
    }
}