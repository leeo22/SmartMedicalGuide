using Microsoft.AspNetCore.Mvc;
using SmartMedicalGuide.API.Base;
using SmartMedicalGuide.Core.Features.Doctors.Commands.Models;
using SmartMedicalGuide.Core.Features.Doctors.Queries.Models;
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
        [HttpPut(Router.DoctorRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditDoctorCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpDelete(Router.DoctorRouting.Delete)]
        public async Task<IActionResult> Delete([FromBody] DeleteDoctorCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpGet(Router.DoctorRouting.GetByID)]
        public async Task<IActionResult> GetDoctorByID([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetDoctorByIDQuery(id));
            return Ok(response);
        }

    }
}
