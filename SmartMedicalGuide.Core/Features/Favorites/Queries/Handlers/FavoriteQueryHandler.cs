using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Favorites.Queries.Models;
using SmartMedicalGuide.Core.Features.Favorites.Queries.Results;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Favorites.Queries.Handlers
{
    public class FavoriteQueryHandler : ResponseHandler,
                                       IRequestHandler<GetFavoriteListQuery, Response<List<GetFavoriteListResponse>>>,
                                       IRequestHandler<GetFavoriteByIDQuery, Response<GetSingleFavoriteResponse>>
    {
        #region Fields
        private readonly IFavoriteServices _favoriteServices;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public FavoriteQueryHandler(IFavoriteServices favoriteServices, IMapper mapper)
        {
            _favoriteServices = favoriteServices;
            _mapper = mapper;
        }
        #endregion

        #region Handlers Functions
        public async Task<Response<List<GetFavoriteListResponse>>> Handle(GetFavoriteListQuery request, CancellationToken cancellationToken)
        {
            var resultList = await _favoriteServices.GetListAsync();

            // فلترة حسب PatientId إذا تم توفيره
            if (request.PatientId.HasValue)
            {
                resultList = resultList.Where(f => f.PatientId == request.PatientId.Value).ToList();
            }

            var resultListMapper = _mapper.Map<List<GetFavoriteListResponse>>(resultList);
            return Success(resultListMapper);
        }

        public async Task<Response<GetSingleFavoriteResponse>> Handle(GetFavoriteByIDQuery request, CancellationToken cancellationToken)
        {
            var result = await _favoriteServices.GetByIDAsync(request.Id);
            if (result == null)
                return NotFound<GetSingleFavoriteResponse>("No favorite found with this ID");

            var result1 = _mapper.Map<GetSingleFavoriteResponse>(result);
            return Success(result1);
        }
        #endregion
    }
}