using Microsoft.AspNetCore.Mvc;
using SmartMedicalGuide.API.Base;
using SmartMedicalGuide.Core.Features.Authentication.Commands.Models;
using SmartMedicalGuide.Core.Features.Authentication.Queries.Models;
using SmartMedicalGuide.Data.AppMetaData;

namespace SmartMedicalGuide.API.Controllers
{
    [ApiController]
    public class AuthenticationController : AppControllerBase
    {
        [HttpPost(Router.Authentication.SignIn)]
        public async Task<IActionResult> Create([FromForm] SignInCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpPost(Router.Authentication.RefreshToken)]
        public async Task<IActionResult> RefreshToken([FromForm] RefreshTokenCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpGet(Router.Authentication.ValidateToken)]
        public async Task<IActionResult> ValidateToken([FromQuery] AuthorizeUserQuery query)
        {
            var response = await Mediator.Send(query);
            return NewResult(response);
        }
        [HttpGet(Router.Authentication.ConfirmEmail)]
        public async Task<IActionResult> ConfirmEmail([FromQuery] ConfirmEmailQuery query)
        {
            var response = await Mediator.Send(query);
            return NewResult(response);
        }
        [HttpPost(Router.Authentication.SendResetPasswordCode)]
        public async Task<IActionResult> SendResetPassword([FromQuery] SendResetPasswordCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpGet(Router.Authentication.ConfirmResetPasswordCode)]
        public async Task<IActionResult> ConfirmResetPassword([FromQuery] ConfirmResetPasswordQuery query)
        {
            var response = await Mediator.Send(query);
            return NewResult(response);
        }
        [HttpPost(Router.Authentication.ResetPassword)]
        public async Task<IActionResult> ResetPassword([FromForm] ResetPasswordCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

    }
}
