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
                                       IRequestHandler<EditFavoriteCommand, Response<string>>,
                                       IRequestHandler<DeleteFavoriteCommand, Response<string>>
    {
        #region Fields
        private readonly IFavoriteServices _favoriteServices;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public FavoriteCommandHandler(IFavoriteServices favoriteServices, IMapper mapper)
        {
            _favoriteServices = favoriteServices;
            _mapper = mapper;
        }
        #endregion

        #region Handlers Functions
        public async Task<Response<string>> Handle(AddFavoriteCommand request, CancellationToken cancellationToken)
        {
            // التحقق من عدم وجود نفس المفضلة مسبقاً
            //var existingFavorite = await _favoriteServices.GetByIDAsync(request.PatientId, request.DoctorId);
            //if (existingFavorite != null)
            //    return BadRequest<string>("This favorite already exists");

            var resultMapper = _mapper.Map<Favorite>(request);
            var result = await _favoriteServices.AddAsync(resultMapper);

            if (result == "Success")
                return Created("Favorite added successfully");
            else
                return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditFavoriteCommand request, CancellationToken cancellationToken)
        {
            var result = await _favoriteServices.GetByIDAsync(request.FavoriteId);
            if (result == null)
                return NotFound<string>("Favorite not found");

            var resultMapper = _mapper.Map<Favorite>(request);
            var result1 = await _favoriteServices.EditAsync(resultMapper);

            if (result1 == "Success")
                return Success("Favorite edited successfully");
            else
                return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteFavoriteCommand request, CancellationToken cancellationToken)
        {
            var result = await _favoriteServices.GetByIDAsync(request.Id);
            if (result == null)
                return NotFound<string>("Favorite not found");

            var result1 = await _favoriteServices.DeleteAsync(result);

            if (result1 == "Success")
                return Deleted<string>($"Favorite deleted successfully: {request.Id}");
            else
                return BadRequest<string>();
        }
        #endregion
    }
}