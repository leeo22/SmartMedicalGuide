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
        IRequestHandler<GetFavoriteByIdQuery, Response<GetSingleFavoriteResponse>>,
        IRequestHandler<IsFavoriteQuery, Response<bool>>,
        IRequestHandler<GetFavoriteDoctorsWithDetailsQuery, Response<List<FavoriteDoctorDto>>>
    {
        private readonly IFavoriteServices _favoriteServices;
        private readonly IMapper _mapper;

        public FavoriteQueryHandler(IFavoriteServices favoriteServices, IMapper mapper)
        {
            _favoriteServices = favoriteServices;
            _mapper = mapper;
        }

        public async Task<Response<List<GetFavoriteListResponse>>> Handle(GetFavoriteListQuery request, CancellationToken cancellationToken)
        {
            List<Favorite> favorites;

            if (request.PatientId.HasValue)
            {
                favorites = await _favoriteServices.GetByPatientIdAsync(request.PatientId.Value);
            }
            else
            {
                favorites = await _favoriteServices.GetListAsync();
            }

            if (request.DoctorId.HasValue)
            {
                favorites = favorites.Where(x => x.DoctorId == request.DoctorId.Value).ToList();
            }

            var result = _mapper.Map<List<GetFavoriteListResponse>>(favorites);
            return Success(result);
        }

        public async Task<Response<GetSingleFavoriteResponse>> Handle(GetFavoriteByIdQuery request, CancellationToken cancellationToken)
        {
            var favorite = await _favoriteServices.GetByIDAsync(request.Id);
            if (favorite == null)
                return NotFound<GetSingleFavoriteResponse>("Favorite not found");

            var result = _mapper.Map<GetSingleFavoriteResponse>(favorite);
            return Success(result);
        }

        public async Task<Response<bool>> Handle(IsFavoriteQuery request, CancellationToken cancellationToken)
        {
            var isFavorite = await _favoriteServices.IsFavoriteAsync(request.PatientId, request.DoctorId);
            return Success(isFavorite);
        }

        public async Task<Response<List<FavoriteDoctorDto>>> Handle(GetFavoriteDoctorsWithDetailsQuery request, CancellationToken cancellationToken)
        {
            var favorites = await _favoriteServices.GetFavoriteDoctorsWithDetailsAsync(request.PatientId);

            var result = favorites.Select(f => new FavoriteDoctorDto
            {
                DoctorId = f.DoctorId,
                DoctorName = f.Doctor?.User?.FullName ?? "Unknown",
                ProfileImageUrl = f.Doctor?.ProfileImageUrl,
                SpecializationName = f.Doctor?.Specialization?.Name ?? "غير محدد",
                ConsultationPrice = f.Doctor?.ConsultationPrice,
                AverageRating = f.Doctor?.Reviews != null && f.Doctor.Reviews.Any()
                    ? f.Doctor.Reviews.Average(r => r.Rating) : 0,
                ReviewsCount = f.Doctor?.Reviews?.Count ?? 0,
                AddedAt = f.CreatedAt
            }).ToList();

            return Success(result);
        }
    }
}