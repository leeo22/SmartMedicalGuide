using Microsoft.AspNetCore.Mvc;
using SmartMedicalGuide.API.Base;
using SmartMedicalGuide.Core.Features.Doctors.Queries.Models;
using SmartMedicalGuide.Data.AppMetaData;

namespace SmartMedicalGuide.API.Controllers
{
    [ApiController]
    public class DoctorAppointmentController : AppControllerBase
    {
        [HttpGet(Router.DoctorRouting.List)]
        public async Task<IActionResult> GetDoctorAppointmentList()
        {
            var response = await Mediator.Send(new GetDoctorAppointmentListQuery());
            return Ok(response);
        }
    }
}
