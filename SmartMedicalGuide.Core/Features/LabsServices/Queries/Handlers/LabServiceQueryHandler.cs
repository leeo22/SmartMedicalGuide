using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.LabsServices.Queries.Models;
using SmartMedicalGuide.Core.Features.LabsServices.Queries.Results;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.LabsServices.Queries.Handlers
{
    public class LabServiceQueryHandler : ResponseHandler,
                                       IRequestHandler<GetLabServiceListQuery, Response<List<GetLabServiceListResponse>>>,
                                       IRequestHandler<GetLabServiceByIDQuery, Response<GetSingleLabServiceResponse>>
    {
        #region Fields
        private readonly ILabServiceServices _labServiceServices;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public LabServiceQueryHandler(ILabServiceServices labServiceServices, IMapper mapper)
        {
            _labServiceServices = labServiceServices;
            _mapper = mapper;
        }
        #endregion

        #region Handlers Functions
        public async Task<Response<List<GetLabServiceListResponse>>> Handle(GetLabServiceListQuery request, CancellationToken cancellationToken)
        {
            var resultList = await _labServiceServices.GetLabServicesListAsync();

            // فلترة حسب LabId إذا تم توفيره
            if (request.LabId.HasValue)
            {
                resultList = resultList.Where(l => l.LabId == request.LabId.Value).ToList();
            }

            var resultListMapper = _mapper.Map<List<GetLabServiceListResponse>>(resultList);
            return Success(resultListMapper);
        }

        public async Task<Response<GetSingleLabServiceResponse>> Handle(GetLabServiceByIDQuery request, CancellationToken cancellationToken)
        {
            var result = await _labServiceServices.GetLabByIDAsync(request.Id);
            if (result == null)
                return NotFound<GetSingleLabServiceResponse>("No lab service found with this ID");

            var result1 = _mapper.Map<GetSingleLabServiceResponse>(result);
            return Success(result1);
        }
        #endregion
    }
}