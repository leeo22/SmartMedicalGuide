using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Reports.Queries.Models;
using SmartMedicalGuide.Core.Features.Reports.Queries.Results;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Reports.Queries.Handlers
{
    public class ReportQueryHandler : ResponseHandler,
                                       IRequestHandler<GetReportListQuery, Response<List<GetReportListResponse>>>,
                                       IRequestHandler<GetReportByIDQuery, Response<GetSingleReportResponse>>
    {
        #region Fields
        private readonly IReportServices _reportServices;
        private readonly IMapper _mapper;

        #endregion

        #region Constructors
        public ReportQueryHandler(IReportServices reportServices, IMapper mapper)
        {
            _reportServices = reportServices;
            _mapper = mapper;
        }
        #endregion

        #region Handels Functions
        public async Task<Response<List<GetReportListResponse>>> Handle(GetReportListQuery request, CancellationToken cancellationToken)
        {
            var resultList = await _reportServices.GetListAsync();
            var resultListMapper = _mapper.Map<List<GetReportListResponse>>(resultList);
            return Success(resultListMapper);
        }

        public async Task<Response<GetSingleReportResponse>> Handle(GetReportByIDQuery request, CancellationToken cancellationToken)
        {
            var result = await _reportServices.GetByIDAsync(request.Id);
            if (result == null) return NotFound<GetSingleReportResponse>("No report same ID");
            var result1 = _mapper.Map<GetSingleReportResponse>(result);
            return Success(result1);
        }
        #endregion

    }
}
