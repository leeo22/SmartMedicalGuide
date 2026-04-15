using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Specializations.Queries.Models;
using SmartMedicalGuide.Core.Features.Specializations.Queries.Results;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Specializations.Queries.Handlers
{
    public class SpecializationQueryHandler : ResponseHandler,
                                       IRequestHandler<GetSpecializationListQuery, Response<List<GetSpecializationListResponse>>>,
                                       IRequestHandler<GetSpecializationByIDQuery, Response<GetSingleSpecializationResponse>>
    {
        #region Fields
        private readonly ISpecializationServices _specializationServices;
        private readonly IMapper _mapper;

        #endregion

        #region Constructors
        public SpecializationQueryHandler(ISpecializationServices specializationServices, IMapper mapper)
        {
            _specializationServices = specializationServices;
            _mapper = mapper;
        }
        #endregion

        #region Handels Functions
        public async Task<Response<List<GetSpecializationListResponse>>> Handle(GetSpecializationListQuery request, CancellationToken cancellationToken)
        {
            var resultList = await _specializationServices.GetListAsync();
            var resultListMapper = _mapper.Map<List<GetSpecializationListResponse>>(resultList);
            return Success(resultListMapper);
        }

        public async Task<Response<GetSingleSpecializationResponse>> Handle(GetSpecializationByIDQuery request, CancellationToken cancellationToken)
        {
            var result = await _specializationServices.GetByIDAsync(request.Id);
            if (result == null) return NotFound<GetSingleSpecializationResponse>("No specialization same ID");
            var result1 = _mapper.Map<GetSingleSpecializationResponse>(result);
            return Success(result1);
        }
        #endregion

    }
}
