<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SmartMedicalGuide.API.Controllers
{
    
    [ApiController]
    public class SystemSettingController : ControllerBase
    {
=======
﻿using Microsoft.AspNetCore.Mvc;
using SmartMedicalGuide.API.Base;
using SmartMedicalGuide.Core.Features.SystemSettings.Commands.Models;
using SmartMedicalGuide.Core.Features.SystemSettings.Queries.Models;
using SmartMedicalGuide.Data.AppMetaData;

namespace SmartMedicalGuide.API.Controllers
{

    [ApiController]
    public class SystemSettingController : AppControllerBase
    {
        [HttpGet(Router.SystemSetting.List)]
        public async Task<IActionResult> GetSystemSettingList()
        {
            var response = await Mediator.Send(new GetSystemSettingListQuery());
            return Ok(response);
        }
        [HttpGet(Router.SystemSetting.GetByID)]
        public async Task<IActionResult> GetByID([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetSystemSettingByIDQuery(id));
            return Ok(response);
        }
        [HttpPost(Router.SystemSetting.Create)]
        public async Task<IActionResult> Create([FromBody] AddSystemSettingCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
>>>>>>> 5544136e3ebc971ee1f59abf8801ca62912e2f8d
    }
}
