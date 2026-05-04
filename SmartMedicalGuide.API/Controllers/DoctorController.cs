using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartMedicalGuide.API.Base;
using SmartMedicalGuide.Core.Features.Doctors.Commands.Models;
using SmartMedicalGuide.Core.Features.Doctors.Queries.Models;
using SmartMedicalGuide.Data.AppMetaData;
using Swashbuckle.AspNetCore.Annotations;

namespace SmartMedicalGuide.API.Controllers
{
    [Authorize]
    [ApiController]
    public class DoctorController : AppControllerBase
    {
        #region Basic CRUD
        [SwaggerOperation(Summary = "Get all doctors", OperationId = "GetAllDoctors")]
        [HttpGet(Router.DoctorRouting.List)]
        public async Task<IActionResult> GetAll([FromQuery] GetDoctorListQuery query)
        {
            var response = await Mediator.Send(query);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get doctor by ID", OperationId = "GetDoctorById")]
        [HttpGet(Router.DoctorRouting.GetByID)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetDoctorByIdQuery(id));
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Create new doctor", OperationId = "CreateDoctor")]
        [HttpPost(Router.DoctorRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddDoctorCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Update doctor", OperationId = "UpdateDoctor")]
        [HttpPut(Router.DoctorRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditDoctorCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Delete doctor (soft delete)", OperationId = "DeleteDoctor")]
        [HttpDelete(Router.DoctorRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await Mediator.Send(new DeleteDoctorCommand(id));
            return NewResult(response);
        }
        #endregion

        #region Additional Queries
        [SwaggerOperation(Summary = "Get doctor by User ID", OperationId = "GetDoctorByUserId")]
        [HttpGet(Router.DoctorRouting.GetByUserId)]
        public async Task<IActionResult> GetByUserId([FromRoute] int userId)
        {
            var response = await Mediator.Send(new GetDoctorByUserIdQuery(userId));
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get doctors by specialization", OperationId = "GetDoctorsBySpecialization")]
        [HttpGet(Router.DoctorRouting.GetBySpecialization)]
        public async Task<IActionResult> GetBySpecialization([FromRoute] int specializationId)
        {
            var response = await Mediator.Send(new GetDoctorsBySpecializationQuery { SpecializationId = specializationId });
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get verified doctors", OperationId = "GetVerifiedDoctors")]
        [HttpGet(Router.DoctorRouting.GetVerified)]
        public async Task<IActionResult> GetVerified()
        {
            var response = await Mediator.Send(new GetVerifiedDoctorsQuery());
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Search doctors", OperationId = "SearchDoctors")]
        [HttpGet(Router.DoctorRouting.Search)]
        public async Task<IActionResult> Search([FromQuery] string keyword)
        {
            var response = await Mediator.Send(new SearchDoctorsQuery { Keyword = keyword });
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get top rated doctors", OperationId = "GetTopRatedDoctors")]
        [HttpGet(Router.DoctorRouting.TopRated)]
        public async Task<IActionResult> GetTopRated([FromQuery] int limit = 10)
        {
            var response = await Mediator.Send(new GetTopRatedDoctorsQuery { Limit = limit });
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get doctors by price range", OperationId = "GetDoctorsByPriceRange")]
        [HttpGet(Router.DoctorRouting.GetByPriceRange)]
        public async Task<IActionResult> GetByPriceRange([FromQuery] decimal minPrice, [FromQuery] decimal maxPrice)
        {
            var response = await Mediator.Send(new GetDoctorsByPriceRangeQuery { MinPrice = minPrice, MaxPrice = maxPrice });
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get doctors available for booking", OperationId = "GetAvailableForBookingDoctors")]
        [HttpGet(Router.DoctorRouting.GetAvailableForBooking)]
        public async Task<IActionResult> GetAvailableForBooking()
        {
            var response = await Mediator.Send(new GetAvailableForBookingDoctorsQuery());
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get doctor with all details", OperationId = "GetDoctorWithDetails")]
        [HttpGet(Router.DoctorRouting.GetWithDetails)]
        public async Task<IActionResult> GetWithDetails([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetDoctorWithDetailsQuery(id));
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get doctor statistics", OperationId = "GetDoctorStatistics")]
        [HttpGet(Router.DoctorRouting.GetStatistics)]
        public async Task<IActionResult> GetStatistics([FromRoute] int doctorId)
        {
            var response = await Mediator.Send(new GetDoctorStatisticsQuery(doctorId));
            return NewResult(response);
        }
        #endregion

        #region Additional Commands
        [SwaggerOperation(Summary = "Update doctor verification status", OperationId = "UpdateVerificationStatus")]
        [HttpPut(Router.DoctorRouting.UpdateVerification)]
        public async Task<IActionResult> UpdateVerificationStatus([FromBody] UpdateVerificationStatusCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Toggle doctor availability for booking", OperationId = "ToggleAvailableForBooking")]
        [HttpPut(Router.DoctorRouting.ToggleAvailable)]
        public async Task<IActionResult> ToggleAvailableForBooking([FromBody] ToggleAvailableForBookingCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        #endregion
    }
}