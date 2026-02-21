using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Labs.Queries.Models;
using SmartMedicalGuide.Core.Features.Labs.Queries.Results;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Labs.Queries.Handlers
{
    public class LabQueryHandler : ResponseHandler,
                                        IRequestHandler<GetLabListQuery, Response<List<GetLabListRespones>>>,
                                        IRequestHandler<GetLabByIDQuery, Response<GetSingleLabResponse>>
    {
        #region Fields
        private readonly ILabServices _labServices;
        private readonly IMapper _mapper;

        #endregion

        #region Constructors
        public LabQueryHandler(ILabServices labServices, IMapper mapper)
        {
            _labServices = labServices;
            _mapper = mapper;
        }


        #endregion

        #region Handels Functions
        public async Task<Response<List<GetLabListRespones>>> Handle(GetLabListQuery request, CancellationToken cancellationToken)
        {
            var labList = await _labServices.GetLabsListAsync();
            var labListMapper = _mapper.Map<List<GetLabListRespones>>(labList);
            return Success(labListMapper);
        }

        public async Task<Response<GetSingleLabResponse>> Handle(GetLabByIDQuery request, CancellationToken cancellationToken)
        {
            var lab = await _labServices.GetLabByIdAsync(request.Id);
            if (lab == null) return NotFound<GetSingleLabResponse>("No Patient same ID");
            var result = _mapper.Map<GetSingleLabResponse>(lab);
            return Success(result);
        }

        #endregion


    }
}
