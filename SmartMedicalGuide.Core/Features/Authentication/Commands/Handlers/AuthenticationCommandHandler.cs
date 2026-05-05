using MediatR;
using Microsoft.AspNetCore.Identity;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Authentication.Commands.Models;
using SmartMedicalGuide.Data.Entities.Identity;
using SmartMedicalGuide.Data.Requests;
using SmartMedicalGuide.Services.Abstracts;
//using Microsoft.AspNetCore.Authentication;

namespace SmartMedicalGuide.Core.Features.Authentication.Commands.Handlers
{
    public class AuthenticationCommandHandler : ResponseHandler,
        IRequestHandler<SignInCommand, Response<JwtAuthResult>>,
    IRequestHandler<RefreshTokenCommand, Response<JwtAuthResult>>,
    IRequestHandler<SendResetPasswordCommand, Response<string>>,
    IRequestHandler<ResetPasswordCommand, Response<string>>
    {


        #region Fields
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IAuthenticationService _authenticationService;


        #endregion

        #region Constructors
        public AuthenticationCommandHandler(UserManager<User> userManager,
                                            SignInManager<User> signInManager,
                                            IAuthenticationService authenticationService)

        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authenticationService = authenticationService;
        }


        #endregion

        #region Handle Functions
        public async Task<Response<JwtAuthResult>> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            //Check if user is exist or not
            var user = await _userManager.FindByNameAsync(request.UserName);
            //Return The UserName Not Found
            if (user == null) return BadRequest<JwtAuthResult>("User Name Is Not Exist");
            //try To Sign in 
            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            //if Failed Return Passord is wrong
            if (!signInResult.Succeeded) return BadRequest<JwtAuthResult>("Password Not Correct");
            //confirm email
            if (!user.EmailConfirmed)
                return BadRequest<JwtAuthResult>("Email Not Confirmed");
            //Generate Token
            var result = await _authenticationService.GetJWTToken(user);
            //return Token 
            return Success(result);
        }

        public async Task<Response<JwtAuthResult>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var jwtToken = _authenticationService.ReadJWTToken(request.AccessToken);
            var userIdAndExpireDate = await _authenticationService.ValidateDetails(jwtToken, request.AccessToken, request.RefreshToken);
            switch (userIdAndExpireDate)
            {
                case ("AlgorithmIsWrong", null): return Unauthorized<JwtAuthResult>("Algorithm Is Wrong");
                case ("TokenIsNotExpired", null): return Unauthorized<JwtAuthResult>("Token Is Not Expired");
                case ("RefreshTokenIsNotFound", null): return Unauthorized<JwtAuthResult>("Refresh Token Is Not Found");
                case ("RefreshTokenIsExpired", null): return Unauthorized<JwtAuthResult>("Refresh Token Is Expired");
            }
            var (userId, expiryDate) = userIdAndExpireDate;
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound<JwtAuthResult>();
            }
            var result = await _authenticationService.GetRefreshToken(user, jwtToken, expiryDate, request.RefreshToken);
            return Success(result);
        }

        public async Task<Response<string>> Handle(SendResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var result = await _authenticationService.SendResetPasswordCode(request.Email);
            switch (result)
            {
                case "UserNotFound": return BadRequest<string>("_stringLocalizer[SharedResourcesKeys.UserIsNotFound]");
                case "ErrorInUpdateUser": return BadRequest<string>("_stringLocalizer[SharedResourcesKeys.TryAgainInAnotherTime]");
                case "Failed": return BadRequest<string>("_stringLocalizer[SharedResourcesKeys.TryAgainInAnotherTime]");
                case "Success": return Success<string>("");
                default: return BadRequest<string>("_stringLocalizer[SharedResourcesKeys.TryAgainInAnotherTime]");
            }
        }

        public async Task<Response<string>> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var result = await _authenticationService.ResetPassword(request.Email, request.Password);
            switch (result)
            {
                case "UserNotFound": return BadRequest<string>("_stringLocalizer[SharedResourcesKeys.UserIsNotFound]");
                case "Failed": return BadRequest<string>("_stringLocalizer[SharedResourcesKeys.InvaildCode]");
                case "Success": return Success<string>("");
                default: return BadRequest<string>("_stringLocalizer[SharedResourcesKeys.InvaildCode]");
            }
        }

        #endregion
    }


}
