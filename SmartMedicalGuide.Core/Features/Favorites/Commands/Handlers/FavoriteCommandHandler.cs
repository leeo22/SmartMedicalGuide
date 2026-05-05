using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Favorites.Commands.Models;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Favorites.Commands.Handlers
{
    public class FavoriteCommandHandler : ResponseHandler,
        IRequestHandler<AddFavoriteCommand, Response<string>>,
        IRequestHandler<DeleteFavoriteCommand, Response<string>>,
        IRequestHandler<ToggleFavoriteCommand, Response<bool>>
    {
        private readonly IFavoriteServices _favoriteServices;
        private readonly IMapper _mapper;

        public FavoriteCommandHandler(IFavoriteServices favoriteServices, IMapper mapper)
        {
            _favoriteServices = favoriteServices;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(AddFavoriteCommand request, CancellationToken cancellationToken)
        {
            var favorite = _mapper.Map<Favorite>(request);
            var result = await _favoriteServices.AddAsync(favorite);

            if (result == "Doctor already in favorites")
                return BadRequest<string>("Doctor already in favorites");
            if (result != "Success")
                return BadRequest<string>(result);

            return Created("Doctor added to favorites successfully");
        }

        public async Task<Response<string>> Handle(DeleteFavoriteCommand request, CancellationToken cancellationToken)
        {
            var favorite = await _favoriteServices.GetByIDAsync(request.Id);
            if (favorite == null)
                return NotFound<string>("Favorite not found");

            var result = await _favoriteServices.DeleteAsync(favorite);
            return result == "Success" ? Deleted<string>("Doctor removed from favorites successfully") : BadRequest<string>(result);
        }

        public async Task<Response<bool>> Handle(ToggleFavoriteCommand request, CancellationToken cancellationToken)
        {
            var result = await _favoriteServices.ToggleFavoriteAsync(request.PatientId, request.DoctorId);
            return Success(result);
        }
    }
}