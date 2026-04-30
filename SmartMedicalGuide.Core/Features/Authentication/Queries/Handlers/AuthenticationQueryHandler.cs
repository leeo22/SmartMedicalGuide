using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Authentication.Queries.Models;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Authentication.Queries.Handlers
{
    internal class AuthenticationQueryHandler : ResponseHandler,
        IRequestHandler<AuthorizeUserQuery, Response<string>>
    //IRequestHandler<ConfirmEmailQuery, Response<string>>,
    //IRequestHandler<ConfirmResetPasswordQuery, Response<string>>
    {


        #region Fields
        private readonly IAuthenticationService _authenticationService;

        #endregion

        #region Constructors
        public AuthenticationQueryHandler(IAuthenticationService authenticationService)
        {

            _authenticationService = authenticationService;
        }


        #endregion

        #region Handle Functions
        public async Task<Response<string>> Handle(AuthorizeUserQuery request, CancellationToken cancellationToken)
        {
            var result = await _authenticationService.ValidateToken(request.AccessToken);
            if (result == "NotExpired")
                return Success(result);
            return Unauthorized<string>("TokenIsExpired");
        }

        //public async Task<Response<string>> Handle(ConfirmEmailQuery request, CancellationToken cancellationToken)
        //{
        //    var confirmEmail = await _authenticationService.ConfirmEmail(request.UserId, request.Code);
        //    if (confirmEmail == "ErrorWhenConfirmEmail")
        //        return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.ErrorWhenConfirmEmail]);
        //    return Success<string>(_stringLocalizer[SharedResourcesKeys.ConfirmEmailDone]);
        //}

        //public async Task<Response<string>> Handle(ConfirmResetPasswordQuery request, CancellationToken cancellationToken)
        //{
        //    var result = await _authenticationService.ConfirmResetPassword(request.Code, request.Email);
        //    switch (result)
        //    {
        //        case "UserNotFound": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.UserIsNotFound]);
        //        case "Failed": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.InvaildCode]);
        //        case "Success": return Success<string>("");
        //        default: return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.InvaildCode]);
        //    }
        //}
        #endregion
    }
}
