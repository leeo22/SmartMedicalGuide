using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartMedicalGuide.API.Base;
using SmartMedicalGuide.Core.Features.Favorites.Commands.Models;
using SmartMedicalGuide.Core.Features.Favorites.Queries.Models;
using SmartMedicalGuide.Data.AppMetaData;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;

namespace SmartMedicalGuide.API.Controllers
{
    [Authorize]
    [ApiController]
    public class FavoriteController : AppControllerBase
    {
        private int GetCurrentPatientId()
        {
            // هذا افتراضي - قد تحتاج إلى ربط PatientId بالـ UserId
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return int.TryParse(userIdClaim, out int userId) ? userId : 0;
        }

        #region Basic CRUD
        [SwaggerOperation(Summary = "Get all favorites", OperationId = "GetAllFavorites")]
        [HttpGet(Router.FavoriteRouting.List)]
        public async Task<IActionResult> GetAll([FromQuery] int? patientId, [FromQuery] int? doctorId)
        {
            var response = await Mediator.Send(new GetFavoriteListQuery { PatientId = patientId, DoctorId = doctorId });
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get favorite by ID", OperationId = "GetFavoriteById")]
        [HttpGet(Router.FavoriteRouting.GetByID)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetFavoriteByIdQuery(id));
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Add doctor to favorites", OperationId = "AddFavorite")]
        [HttpPost(Router.FavoriteRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddFavoriteCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Remove doctor from favorites", OperationId = "DeleteFavorite")]
        [HttpDelete(Router.FavoriteRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await Mediator.Send(new DeleteFavoriteCommand(id));
            return NewResult(response);
        }
        #endregion

        #region Additional Important Endpoints
        [SwaggerOperation(Summary = "Get my favorite doctors", OperationId = "GetMyFavorites")]
        [HttpGet(Router.FavoriteRouting.GetMyFavorites)]
        public async Task<IActionResult> GetMyFavorites()
        {
            var patientId = GetCurrentPatientId();
            if (patientId == 0)
                return Unauthorized();

            var response = await Mediator.Send(new GetFavoriteListQuery { PatientId = patientId });
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get my favorite doctors with details", OperationId = "GetMyFavoriteDoctorsWithDetails")]
        [HttpGet(Router.FavoriteRouting.GetMyFavoritesWithDetails)]
        public async Task<IActionResult> GetMyFavoritesWithDetails()
        {
            var patientId = GetCurrentPatientId();
            if (patientId == 0)
                return Unauthorized();

            var response = await Mediator.Send(new GetFavoriteDoctorsWithDetailsQuery { PatientId = patientId });
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Check if doctor is favorite", OperationId = "IsFavorite")]
        [HttpGet(Router.FavoriteRouting.IsFavorite)]
        public async Task<IActionResult> IsFavorite([FromQuery] int doctorId)
        {
            var patientId = GetCurrentPatientId();
            if (patientId == 0)
                return Unauthorized();

            var response = await Mediator.Send(new IsFavoriteQuery { PatientId = patientId, DoctorId = doctorId });
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Toggle favorite (add/remove)", OperationId = "ToggleFavorite")]
        [HttpPost(Router.FavoriteRouting.Toggle)]
        public async Task<IActionResult> Toggle([FromBody] ToggleFavoriteCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get favorite count by doctor", OperationId = "GetFavoriteCountByDoctor")]
        [HttpGet(Router.FavoriteRouting.GetCountByDoctor)]
        public async Task<IActionResult> GetCountByDoctor([FromQuery] int doctorId)
        {
            // يمكن إضافة Service مباشرة هنا أو عبر Mediator
            return Ok();
        }
        #endregion
    }
}