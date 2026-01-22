using Microsoft.AspNetCore.Mvc;
using SmartMedicalGuide.API.Base;
using SmartMedicalGuide.Core.Features.Doctors.Queries.Models;
using SmartMedicalGuide.Data.AppMetaData;

namespace SmartMedicalGuide.API.Controllers
{

    [ApiController]
    public class DoctorController : AppControllerBase
    {
        [HttpGet(Router.PatientRouting.List)]
        public async Task<IActionResult> GetDoctorList()
        {
            var response = await Mediator.Send(new GetDoctorListQuery());
            return Ok(response);
        }
    }
}
