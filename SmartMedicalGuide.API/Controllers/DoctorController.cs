using Microsoft.AspNetCore.Mvc;
using SmartMedicalGuide.API.Base;
using SmartMedicalGuide.Core.Features.Doctors.Queries.Models;
using SmartMedicalGuide.Core.Features.Users.Commands.Models;
using SmartMedicalGuide.Data.AppMetaData;

namespace SmartMedicalGuide.API.Controllers
{

    [ApiController]
    public class DoctorController : AppControllerBase
    {
        [HttpGet(Router.DoctorRouting.List)]
        public async Task<IActionResult> GetDoctorList()
        {
            var response = await Mediator.Send(new GetDoctorListQuery());
            return Ok(response);
        }

        [HttpPost(Router.DoctorRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddDoctorCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
    }
}
