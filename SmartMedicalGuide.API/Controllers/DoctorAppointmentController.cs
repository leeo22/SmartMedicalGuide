using Microsoft.AspNetCore.Mvc;
using SmartMedicalGuide.API.Base;
using SmartMedicalGuide.Core.Features.DoctorAppointments.Commands.Models;
using SmartMedicalGuide.Core.Features.Doctors.Queries.Models;
using SmartMedicalGuide.Data.AppMetaData;

namespace SmartMedicalGuide.API.Controllers
{
    [ApiController]
    public class DoctorAppointmentController : AppControllerBase
    {
        [HttpGet(Router.DoctorAppointmentRouting.List)]
        public async Task<IActionResult> GetDoctorAppointmentList()
        {
            var response = await Mediator.Send(new GetDoctorAppointmentListQuery());
            return Ok(response);
        }
        [HttpPost(Router.DoctorAppointmentRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddDoctorAppointmentCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
    }
}
