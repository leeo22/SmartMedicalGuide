//using MediatR;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using SmartMedicalGuide.API.Base;
//using SmartMedicalGuide.Core.Features.DoctorSchedules.Commands.Models;
//using SmartMedicalGuide.Core.Features.DoctorSchedules.Queries.Models;
//using SmartMedicalGuide.Data.AppMetaData;

//namespace SmartMedicalGuide.API.Controllers
//{

//    [ApiController]
//    public class DoctorScheduleController : AppControllerBase
//    {
//        [HttpGet(Router.DoctorScheduleRouting.List)]
//        public async Task<IActionResult> GetDoctorScheduleList()
//        {
//            var response = await Mediator.Send(new GetDoctorScheduleListQuery());
//            return Ok(response);
//        }

//        [HttpPost(Router.DoctorScheduleRouting.Create)]
//        public async Task<IActionResult> Create([FromBody] AddDoctorScheduleCommand command)
//        {
//            var response = await Mediator.Send(command);
//            return NewResult(response);
//        }
//        [HttpPut(Router.DoctorScheduleRouting.Edit)]
//        public async Task<IActionResult> Edit([FromBody] EditDoctorScheduleCommand command)
//        {
//            var response = await Mediator.Send(command);
//            return NewResult(response);
//        }
//        [HttpDelete(Router.DoctorScheduleRouting.Delete)]
//        public async Task<IActionResult> Delete([FromBody] DeleteDoctorScheduleCommand command)
//        {
//            var response = await Mediator.Send(command);
//            return NewResult(response);
//        }
//        [HttpGet(Router.DoctorScheduleRouting.GetByID)]
//        public async Task<IActionResult> GetDoctorScheduleByID([FromRoute] int id)
//        {
//            var response = await Mediator.Send(new GetDoctorScheduleByIDQuery(id));
//            return Ok(response);
//        }

//    }
//}
