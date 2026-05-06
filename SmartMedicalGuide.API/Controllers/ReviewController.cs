using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartMedicalGuide.API.Base;
using SmartMedicalGuide.Core.Features.Reviews.Commands.Models;
using SmartMedicalGuide.Core.Features.Reviews.Queries.Models;
using SmartMedicalGuide.Data.AppMetaData;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;

namespace SmartMedicalGuide.API.Controllers
{
    [Authorize]
    [ApiController]
    public class ReviewController : AppControllerBase
    {
        private int GetCurrentPatientId()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return int.TryParse(userIdClaim, out int userId) ? userId : 0;
        }

        #region Basic CRUD
        [SwaggerOperation(Summary = "Get all reviews", OperationId = "GetAllReviews")]
        [HttpGet(Router.ReviewRouting.List)]
        public async Task<IActionResult> GetAll([FromQuery] string? targetType, [FromQuery] int? targetId,
                                                  [FromQuery] int? patientId, [FromQuery] int? minRating, [FromQuery] int? maxRating)
        {
            var response = await Mediator.Send(new GetReviewListQuery
            {
                TargetType = targetType,
                TargetId = targetId,
                PatientId = patientId,
                MinRating = minRating,
                MaxRating = maxRating
            });
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get review by ID", OperationId = "GetReviewById")]
        [HttpGet(Router.ReviewRouting.GetByID)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetReviewByIdQuery(id));
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Create new review", OperationId = "CreateReview")]
        [HttpPost(Router.ReviewRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddReviewCommand command)
        {
            var patientId = GetCurrentPatientId();
            if (patientId == 0)
                return Unauthorized();

            command.PatientId = patientId;
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Update review", OperationId = "UpdateReview")]
        [HttpPut(Router.ReviewRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditReviewCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Delete review", OperationId = "DeleteReview")]
        [HttpDelete(Router.ReviewRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await Mediator.Send(new DeleteReviewCommand(id));
            return NewResult(response);
        }
        #endregion

        #region Additional Important Endpoints
        [SwaggerOperation(Summary = "Get reviews by target (Doctor/Lab)", OperationId = "GetReviewsByTarget")]
        [HttpGet(Router.ReviewRouting.GetByTarget)]
        public async Task<IActionResult> GetByTarget([FromQuery] string targetType, [FromQuery] int targetId)
        {
            var response = await Mediator.Send(new GetReviewListQuery { TargetType = targetType, TargetId = targetId });
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get my reviews", OperationId = "GetMyReviews")]
        [HttpGet(Router.ReviewRouting.GetMyReviews)]
        public async Task<IActionResult> GetMyReviews()
        {
            var patientId = GetCurrentPatientId();
            if (patientId == 0)
                return Unauthorized();

            var response = await Mediator.Send(new GetReviewListQuery { PatientId = patientId });
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get average rating for target", OperationId = "GetAverageRating")]
        [HttpGet(Router.ReviewRouting.GetAverageRating)]
        public async Task<IActionResult> GetAverageRating([FromQuery] string targetType, [FromQuery] int targetId)
        {
            var response = await Mediator.Send(new GetAverageRatingQuery { TargetType = targetType, TargetId = targetId });
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get rating distribution for target", OperationId = "GetRatingDistribution")]
        [HttpGet(Router.ReviewRouting.GetRatingDistribution)]
        public async Task<IActionResult> GetRatingDistribution([FromQuery] string targetType, [FromQuery] int targetId)
        {
            var response = await Mediator.Send(new GetRatingDistributionQuery { TargetType = targetType, TargetId = targetId });
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get recent reviews", OperationId = "GetRecentReviews")]
        [HttpGet(Router.ReviewRouting.GetRecentReviews)]
        public async Task<IActionResult> GetRecentReviews([FromQuery] string targetType, [FromQuery] int targetId,
                                                          [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var response = await Mediator.Send(new GetRecentReviewsQuery { TargetType = targetType, TargetId = targetId, Page = page, PageSize = pageSize });
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Check if patient reviewed target", OperationId = "CheckReviewed")]
        [HttpGet(Router.ReviewRouting.CheckReviewed)]
        public async Task<IActionResult> CheckReviewed([FromQuery] string targetType, [FromQuery] int targetId)
        {
            var patientId = GetCurrentPatientId();
            if (patientId == 0)
                return Unauthorized();

            var response = await Mediator.Send(new CheckPatientReviewedQuery { PatientId = patientId, TargetType = targetType, TargetId = targetId });
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get review statistics", OperationId = "GetReviewStatistics")]
        [HttpGet(Router.ReviewRouting.GetStatistics)]
        public async Task<IActionResult> GetStatistics()
        {
            var response = await Mediator.Send(new GetReviewStatisticsQuery());
            return NewResult(response);
        }
        #endregion
    }
}