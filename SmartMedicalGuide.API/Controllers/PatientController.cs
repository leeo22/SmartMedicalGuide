using Microsoft.AspNetCore.Mvc;
using SmartMedicalGuide.API.Base;
using SmartMedicalGuide.Core.Features.Patients.Commands.Models;
using SmartMedicalGuide.Core.Features.Patients.Queries.Models;
using SmartMedicalGuide.Data.AppMetaData;

namespace SmartMedicalGuide.API.Controllers
{

    [ApiController]
    public class PatientController : AppControllerBase
    {
        #region Fields

        #endregion

        #region Constructors

        #endregion

        #region Handels Functions
        [HttpGet(Router.PatientRouting.List)]
        public async Task<IActionResult> GetPatientList()
        {
            var response = await Mediator.Send(new GetPatientListQuery());
            return Ok(response);
        }

        [HttpGet(Router.PatientRouting.GetByID)]
        public async Task<IActionResult> GetPatientByID([FromRoute] int id)
        {

            return NewResult(await Mediator.Send(new GetPatientByIDQuery(id)));
        }

        [HttpPost(Router.PatientRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddPatientCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpPut(Router.PatientRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditPatientCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpDelete(Router.PatientRouting.Delete)]
        public async Task<IActionResult> Delete([FromBody] DeletePatientCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        #endregion



    }
}
